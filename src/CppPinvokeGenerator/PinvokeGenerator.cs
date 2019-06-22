using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CppAst;
using CppPinvokeGenerator.Templates;
using Microsoft.Extensions.Logging;

namespace CppPinvokeGenerator
{
    public class PinvokeGenerator
    {
        private static readonly ILogger Logger = LoggerFactory.GetLogger<TypeMapper>();

        /// <param name="dllImportPath">will be used as the first argument in [DllImport]. Can be a path to some constant</param>
        /// <param name="generateCForGlobalFunctions">sometimes global functions are ready to be pinvoked as is</param>
        public static void Generate(TypeMapper mapper, TemplateManager templateManager, string @namespace, string dllImportPath, string outCFile, string outCsFile, bool generateCForGlobalFunctions = true)
        {
            var csFileSb = new StringBuilder();
            var cFileSb = new StringBuilder();
            foreach (CppClassContainer cppClass in mapper.GetAllClasses())
            {
                int methodsBound = 0;
                int ctors = 0;

                cFileSb.AppendLine();
                cFileSb.AppendLine();
                cFileSb.AppendLine();
                cFileSb.AppendLine(cppClass.IsGlobal
                    ? $"/************* Global functions: *************/"
                    : $"/************* Type: {cppClass.Class.GetFullTypeName()} *************/");
                cFileSb.AppendLine();

                var csClassSb = new StringBuilder();
                List<CppFunction> allFunctions = cppClass.Functions;
                for (int i = 0; i < allFunctions.Count; i++)
                {
                    CppFunction function = allFunctions[i];

                    if (!mapper.IsSupported(function.ReturnType.GetDisplayName()) ||
                        !function.Parameters.All(p => mapper.IsSupported(p.Type.GetDisplayName())) ||
                        function.IsOperator())
                    {
                        cFileSb.AppendLine($"//NOT_BOUND:  " + function).AppendLine();
                        Logger.LogWarning($"Ignoring {function.Name}");
                        // we can't bind this method (yet)
                        continue;
                    }

                    if (function.IsConstructor)
                        ctors++;
                    methodsBound++;

                    // Type_MethodName1
                    string flatFunctionName = $"{cppClass.Name}_{function.Name}_{function.ParametersMask()}";
                    if (!generateCForGlobalFunctions)
                        flatFunctionName = function.Name; // we are going to pinvoke it directly

                    var cfunctionWriter = new FunctionWriter();
                    var dllImportWriter = new FunctionWriter();
                    // TODO: apiFunctionWriter = new FunctionWriter();

                    dllImportWriter.Attribute($"[DllImport({dllImportPath}, CallingConvention = CallingConvention.Cdecl)]")
                        .Private().Static().Extern();

                    if (function.IsConstructor)
                    {
                        cfunctionWriter.ReturnType(cppClass.Class.GetFullTypeName() + "*", "EXPORTS");
                        dllImportWriter.ReturnType(nameof(IntPtr));
                    }
                    else
                    {
                        var funcReturnType = function.ReturnType.GetFullTypeName();
                        cfunctionWriter.ReturnType(funcReturnType, "EXPORTS");
                        dllImportWriter.ReturnType(mapper.MapToManagedType(funcReturnType));
                    }

                    // PS: should we generate C for global functions (we currently do)? probably it should be optional

                    cfunctionWriter.MethodName(flatFunctionName);
                    dllImportWriter.MethodName(flatFunctionName);

                    if (!function.IsConstructor &&
                        !function.IsStatic() &&
                        !cppClass.IsGlobal)
                    {
                        // all instance methods will have "this" as the first argument
                        cfunctionWriter.Parameter(cppClass.Class.GetFullTypeName() + "*", "target");
                        dllImportWriter.Parameter(nameof(IntPtr), "target");
                    }

                    foreach (var parameter in function.Parameters)
                    {
                        cfunctionWriter.Parameter(
                            parameter.Type.GetDisplayName(),
                            parameter.Name);

                        dllImportWriter.Parameter(
                            mapper.MapToManagedType(parameter.Type.GetDisplayName()),
                            mapper.EscapeVariableName(parameter.Name));
                    }

                    // append "return" if needed
                    cfunctionWriter.BodyStart();

                    if (cppClass.IsGlobal)
                    {
                        // GlobalMethod
                        cfunctionWriter.BodyCallMethod(function.Name);
                    }
                    else if(!function.IsConstructor && !function.IsStatic())
                    {
                        // target->InstanceMethod
                        cfunctionWriter.BodyCallMethod($"target->{function.Name}");
                    }
                    else if (function.IsStatic())
                    {
                        // Class1::StaticMethod
                        cfunctionWriter.BodyCallMethod(cppClass.Class.GetFullTypeName() + "::" + function.Name);
                    }
                    else
                    {
                        // new Class1
                        cfunctionWriter.BodyCallMethod($"new {cppClass.Class.GetFullTypeName()}");
                    }


                    foreach (var parameter in function.Parameters)
                    {
                        cfunctionWriter.PassParameter(parameter.Name);
                    }

                    csClassSb.AppendLine(dllImportWriter.BuildWithoutBody().Tabify(2));
                    csClassSb.AppendLine();

                    cFileSb.AppendLine(cfunctionWriter.Build());
                    cFileSb.AppendLine();
                }

                if (cppClass.IsGlobal && generateCForGlobalFunctions)
                    csFileSb.Append(templateManager.CSharpGlobalClass(csClassSb.ToString(), dllImportPath));
                else if (!cppClass.IsGlobal)
                {
                    csFileSb.Append(templateManager.CSharpClass(cppClass.Name, cppClass.Name, csClassSb.ToString(), dllImportPath));

                    // Append "delete" method:
                    // EXPORTS(void) %class%_delete(%class%* target) { if (target) delete target; }
                    var cfunctionWriter = new FunctionWriter();
                    cfunctionWriter.ReturnType("[EXPORT(void)]")
                        .MethodName(cppClass.Name + "__delete")
                        .Parameter(cppClass.Class.GetFullTypeName() + "*", "target")
                        .BodyStart()
                        .Body("delete target");
                    cFileSb
                        .AppendLine(cfunctionWriter.Build());
                }
            }

            File.WriteAllText(outCFile, templateManager.CHeader() + cFileSb);
            File.WriteAllText(outCsFile, templateManager.CSharpHeader(@namespace, csFileSb.ToString()));
        }
    }
}