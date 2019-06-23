using System;
using System.IO;
using System.Net.Http;
using CppAst;
using CppPinvokeGenerator;
using CppPinvokeGenerator.Templates;

namespace SimdJson
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // In this sample we are going to bind a few C++ classes from https://github.com/lemire/simdjson
            // the library has "singleheader" file so we don't have to collect all needed files + includes
            // see https://github.com/lemire/simdjson/tree/master/singleheader


            string outputFolder = "../../../Output/";
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            Console.WriteLine("Downloading simdjson sources...");

            HttpClient httpClient = new HttpClient();
            string simdJsonSingleHeader = httpClient.GetStringAsync("https://raw.githubusercontent.com/lemire/simdjson/master/singleheader/simdjson.h").Result;
            File.WriteAllText(Path.Combine(outputFolder, @"simdjson.h"), simdJsonSingleHeader);

            Console.WriteLine("Downloaded! Parsing...");

            var options = new CppParserOptions();
            // TODO: test on macOS
            options.ConfigureForWindowsMsvc(CppTargetCpu.X86_64);
            options.AdditionalArguments.Add("-std=c++17");
            CppCompilation compilation = CppParser.ParseFile(Path.Combine(outputFolder, @"simdjson.h"), options);

            if (compilation.DumpErrorsIfAny())
            {
                Console.ReadKey();
                return;
            }

            var mapper = new TypeMapper(compilation);
            mapper.RenamingForApi += (nativeName, isMethod) =>
                {
                    if (nativeName == "iterator")
                        return "ParsedJsonIteratorN";
                    if (!isMethod)
                        return nativeName + "N"; // SimdJsonSharp has two C# APIs: 1) managed 2) bindings - postfixed with 'N'
                    if (nativeName == "get_type")
                        return "GetTokenType";
                    return nativeName;
                };

            // init_state_machine requires external linkage (impl)
            mapper.RegisterUnsupportedMethod(null, "init_state_machine");

            // Register native types we don't want to bind (or any method with them in parameters)
            mapper.RegisterUnsupportedTypes(
                "simdjson", // it's empty - we don't need it
                "basic_string",      // TODO:
                "basic_string_view", // TODO
                "basic_ostream");    // TODO:

            var templateManager = new TemplateManager();

            // Add additional stuff we want to see in the bindings.c
            templateManager
                .AddToCHeader(@"#include ""simdjson.h""")
                .SetGlobalFunctionsClassName("SimdJsonN");

            PinvokeGenerator.Generate(mapper, 
                templateManager, 
                @namespace: "SimdJsonSharp", 
                dllImportPath: @"SimdJsonN.NativeLib",
                outCFile:  Path.Combine(outputFolder, "Bindings.Generated.c"),
                outCsFile: Path.Combine(outputFolder, "Bindings.Generated.cs"));

            Console.WriteLine("Done. See Output folder.");
        }
    }
}
