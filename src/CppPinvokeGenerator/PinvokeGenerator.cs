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

        public static void Generate(TypeMapper mapper, TemplateManager templateManager, string @namespace, string dllImportPath, string outCFile, string outCsFile)
        {
            var csFileSb = new StringBuilder();
            var cFileSb = new StringBuilder();
            foreach (CppClass cppClass in mapper.GetAllClasses())
            {
                var csClassSb = new StringBuilder();
                List<CppFunction> allFunctions = cppClass.GetFunctionsAndConstructors();
                for (int i = 0; i < allFunctions.Count; i++)
                {
                    CppFunction function = allFunctions[i];

                    if (!mapper.IsSupported(function.ReturnType.GetDisplayName()) ||
                        !function.Parameters.All(p => mapper.IsSupported(p.Type.GetDisplayName())) ||
                        function.IsOperator())
                    {
                        Logger.LogWarning($"Ignoring {function.Name}");
                        // we can't bind this method (yet)
                        continue;
                    }

                    // Type_MethodName1
                    string flatFunctionName = $"{cppClass.GetDisplayName()}_{function.Name}{i}";

                    var cfunctionWriter = new FunctionWriter();
                    var dllImportWriter = new FunctionWriter();
                    // TODO: apiFunctionWriter = new FunctionWriter();

                    dllImportWriter.Attribute($"[DllImport({dllImportPath}, CallingConvention = CallingConvention.Cdecl)]")
                        .Private().Static().Extern();

                    if (function.IsConstructor)
                    {
                        cfunctionWriter.ReturnType(cppClass.GetFullTypeName() + "*", "EXPORTS");
                        dllImportWriter.ReturnType(nameof(IntPtr));
                    }
                    else
                    {
                        var funcReturnType = function.ReturnType.GetFullTypeName();
                        cfunctionWriter.ReturnType(funcReturnType, "EXPORTS");
                        dllImportWriter.ReturnType(mapper.MapToManagedType(funcReturnType));
                    }

                    cfunctionWriter.MethodName(flatFunctionName);
                    dllImportWriter.MethodName(flatFunctionName);

                    if (!function.IsConstructor &&
                        !function.IsStatic())
                    {
                        // all instance methods will have "this" as the first argument
                        cfunctionWriter.Parameter(cppClass.GetFullTypeName() + "*", "target");
                        dllImportWriter.Parameter(nameof(IntPtr), "target");
                    }

                    foreach (var parameter in function.Parameters)
                    {
                        cfunctionWriter.Parameter(
                            parameter.Type.GetDisplayName(),
                            parameter.Name);

                        dllImportWriter.Parameter(
                            mapper.MapToManagedType(parameter.Type.GetDisplayName()),
                            parameter.Name);
                    }

                    // append "return" if needed
                    cfunctionWriter.BodyStart();

                    if (!function.IsConstructor &&
                        !function.IsStatic())
                    {
                        // target->InstanceMethod
                        cfunctionWriter.BodyCallMethod($"target->{function.Name}");
                    }
                    else if (function.IsStatic())
                    {
                        // Class1::StaticMethod
                        cfunctionWriter.BodyCallMethod(cppClass.GetFullTypeName() + "::" + function.Name);
                    }
                    else
                    {
                        // new Class1
                        cfunctionWriter.BodyCallMethod($"new {cppClass.GetFullTypeName()}");
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

                csFileSb.Append(templateManager.CSharpClass(cppClass.GetDisplayName(), 
                    cppClass.GetDisplayName(), csClassSb.ToString(), dllImportPath));
            }

            File.WriteAllText(outCFile, templateManager.CHeader() + cFileSb);
            File.WriteAllText(outCsFile, templateManager.CSharpHeader(@namespace, csFileSb.ToString()));
        }
    }
}