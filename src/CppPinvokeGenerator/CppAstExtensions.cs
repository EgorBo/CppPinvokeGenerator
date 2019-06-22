using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CppAst;

namespace CppPinvokeGenerator
{
    public static class CppAstExtensions
    {
        public static bool IsVoid(this CppType type) => type.GetDisplayName() == "void";

        public static bool IsBool(this CppType type) => type.GetDisplayName() == "bool";

        public static bool IsOperator(this CppFunction func) => func.Name.StartsWith("operator"); // TODO: regex?

        public static bool IsStatic(this CppFunction func) => func.StorageQualifier == CppStorageQualifier.Static;
        
        /// <summary>
        /// If a type defined under another type, then print the full name, e.g. Class1::Class2
        /// </summary>
        public static string GetFullTypeName(this CppType cppType)
        {
            string name = cppType.GetDisplayName();
            while (cppType.Parent is CppType parentType)
            {
                name = parentType.GetDisplayName() + "::" + name;
                cppType = parentType;
            }
            return name;
        }

        public static List<CppClass> GetAllClassesRecursively(this CppCompilation compilation)
        {
            var cppClasses = new List<CppClass>();
            foreach (var cppClass in compilation.Classes)
                VisitClass(cppClasses, cppClass);
            return cppClasses;
        }

        private static void VisitClass(List<CppClass> cppClasses, CppClass cppClass)
        {
            cppClasses.Add(cppClass);
            foreach (var subClass in cppClass.Classes)
                VisitClass(cppClasses, subClass);
        }

        public static bool DumpErrorsIfAny(this CppCompilation compilation)
        {
            if (!compilation.Diagnostics.HasErrors)
                return false;

            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            foreach (var dgn in compilation.Diagnostics.Messages)
                if (dgn.Type == CppLogMessageType.Error)
                    Console.WriteLine($"{dgn.Text} at {dgn.Location}");

            Console.ForegroundColor = color;

            return true;
        }

        /// <summary>
        /// E.g.: "void Foo(int age, char* name)" ==> "ic" (first letters of parameters' types)
        /// </summary>
        public static string ParametersMask(this CppFunction function)
        {
            var sb = new StringBuilder();
            var parameters = function.Parameters.ToList();
            if (parameters.Count < 1)
                sb.Append("0");
            else
                foreach (var p in parameters)
                {
                    var type = p.Type.GetDisplayName()
                        .Replace("const ", "")
                        .Replace("*", "")
                        .Replace("&", "")
                        .Trim();

                    sb.Append(type[0]);
                }

            return sb.ToString();
        }
    }
}