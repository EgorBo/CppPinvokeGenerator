using System;
using System.IO;
using System.Text;

namespace CppPinvokeGenerator.Templates
{
    public class TemplateManager
    {
        private string cheader = "";

        public void AddToCHeader(string content) 
            => cheader = content + "\n";

        public string CHeader() 
            => GetEmbeddedResource("CHeader.txt") + cheader;

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
