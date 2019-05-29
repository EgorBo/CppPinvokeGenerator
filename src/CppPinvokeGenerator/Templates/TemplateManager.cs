using System;
using System.IO;
using System.Text;

namespace CppPinvokeGenerator.Templates
{
    public class TemplateManager
    {
        private string cHeader = "";
        private string csGlobalClass = "GlobalFunctions";

        public TemplateManager AddToCHeader(string content)
        {
            cHeader += content + "\n";
            return this;
        }

        public TemplateManager SetGlobalFunctionsClassName(string className)
        {
            csGlobalClass = className;
            return this;
        }

        public string CHeader() 
            => GetEmbeddedResource("CHeader.txt") + cHeader;

        public string CSharpHeader(string @namespace, string content) 
            => GetEmbeddedResource("CSharpHeader.txt")
                .Replace("%NAMESPACE%", @namespace)
                .Replace("%CONTENT%", content.Trim('\n', '\r'));

        public string CSharpClass(string className, string nativeClassName, string dllImportsContent, string nativeLibraryPath)
            => GetEmbeddedResource("CSharpClass.txt")
                .Replace("%CLASS_NAME%", className)
                .Replace("%CCLASS_NAME%", nativeClassName)
                .Replace("%DLLIMPORTS%", dllImportsContent.Trim('\n', '\r'))
                .Replace("%NATIVE_LIBRARY_PATH%", nativeLibraryPath);

        public string CSharpGlobalClass(string dllImportsContent, string nativeLibraryPath)
            => GetEmbeddedResource("CSharpGlobalClass.txt")
                .Replace("%CLASS_NAME%", csGlobalClass)
                .Replace("%DLLIMPORTS%", dllImportsContent.Trim('\n', '\r'))
                .Replace("%NATIVE_LIBRARY_PATH%", nativeLibraryPath);

        private string GetEmbeddedResource(string file)
        {
            using (Stream stream = typeof(TemplateManager).Assembly.GetManifestResourceStream("CppPinvokeGenerator.Templates." + file))
            {
                using (var ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    ms.Position = 0;
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }
    }
}
