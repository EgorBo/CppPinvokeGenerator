using System;
using System.Collections.Generic;
using System.Linq;
using CppAst;
using Microsoft.Extensions.Logging;

namespace CppPinvokeGenerator
{
    public class TypeMapper
    {
        private static readonly ILogger Logger = LoggerFactory.GetLogger<TypeMapper>();

        private readonly CppCompilation _cppCompilation;
        private readonly HashSet<string> _registeredTypes = new HashSet<string>();
        private readonly HashSet<string> _unsupportedTypes = new HashSet<string>();
        private readonly Dictionary<string, string> _mappings = new Dictionary<string, string>
            {
                // stdint.h types:
                { "uint8_t",           nameof(Byte) },
                { "uint16_t",          nameof(UInt16) },
                { "uint32_t",          nameof(UInt32) },
                { "uint64_t",          nameof(UInt64) },
                { "usize_t" ,          nameof(UIntPtr) + "/*usize_t*/" }, // .NET really needs native integers
                { "uintptr_t" ,        nameof(UIntPtr) }, // should we use nuint here too?
                { "int8_t",            nameof(SByte) },
                { "int16_t",           nameof(Int16) },
                { "int32_t",           nameof(Int32) },
                { "int64_t",           nameof(Int64) },
                { "size_t" ,           nameof(IntPtr) + "/*size_t*/"},
                { "intptr_t" ,         nameof(IntPtr)},

                // standard types:
                { "bool",               nameof(Byte) }, //bool is not blittable
                { "char",               nameof(SByte) },
                { "unsigned char",      nameof(Byte) },
                { "signed char",        nameof(SByte) },
                { "short",              nameof(Int16) },
                { "short int",          nameof(Int16) },
                { "signed short",       nameof(Int16) },
                { "signed short int",   nameof(Int16) },
                { "unsigned short",     nameof(UInt16) },
                { "unsigned short int", nameof(UInt16) },
                { "int",                nameof(Int32) },
                { "signed",             nameof(Int32) },
                { "signed int",         nameof(Int32) },
                { "unsigned",           nameof(UInt32) },
                { "unsigned int",       nameof(UInt32) },
                { "long",               nameof(Int64) },
                { "long int",           nameof(Int64) },
                { "signed long",        nameof(Int64) },
                { "signed long int",    nameof(Int64) },
                { "unsigned long",      nameof(UInt64) },
                { "unsigned long int",  nameof(UInt64) },
                { "float",              nameof(Single) },
                { "double",             nameof(Double) },
                // TODO: long double, wchar_t ?

                { "void", "void" },
                { "void*", nameof(IntPtr) },
            };

        private readonly string[] _illiegalVariableNames =
            {
                // will be prefixed with @
                "var",
                "namespace",
                "ref",
                "out",
                "class",
            };

        public CppCompilation CppCompilation => _cppCompilation;

        public TypeMapper(CppCompilation cppCompilation)
        {
            _cppCompilation = cppCompilation;
            foreach (CppClass cppClass in cppCompilation.GetAllClassesRecursively())
            {
                string displayName = cppClass.GetDisplayName();
                RegisterClass(CleanType(displayName));
            }
            Logger.LogDebug("Inited.");
        }

        public IEnumerable<CppClassContainer> GetAllClasses()
        {
            foreach (var cppClass in _cppCompilation.GetAllClassesRecursively())
            {
                if (IsSupported(cppClass.GetDisplayName()))
                    yield return new CppClassContainer(cppClass);
            }

            // "Global" class for global functions
            yield return new CppClassContainer(_cppCompilation.Functions);
        }

        public void RegisterClass(string className)
        {
            Logger.LogDebug($"RegisterClass({className})");
            _registeredTypes.Add(className);
        }

        public void RegisterMapping(string nativeType, string managedType)
        {
            Logger.LogDebug($"RegisterMapping({nativeType}, {managedType})");
            _mappings[nativeType] = managedType;
        }

        public void RegisterUnsupportedTypes(params string[] types)
        {
            foreach (string type in types)
            {
                Logger.LogDebug($"RegisterUnsupportedType(t);");
                _registeredTypes.Remove(type);
                _unsupportedTypes.Add(CleanType(type));
            }
        }

        public string MapToManagedType(string type)
        {
            bool isPtr = type.Trim().EndsWith("*");
            type = CleanType(type);

            if (_mappings.TryGetValue(type, out string managedType))
                return managedType + (isPtr ? "*" : "");

            if (isPtr && _mappings.TryGetValue(type + "*", out string managedTypePtr))
                return managedTypePtr;

            if (_registeredTypes.Contains(type))
                return "IntPtr";

            Logger.LogWarning($"No C# equivalent for {type}");
            return type + (isPtr ? "*" : "");
        }

        public bool IsSupported(string type)
        {
            // skip rvalues
            if (type.Contains("&&"))
                return false;

            return !_unsupportedTypes.Contains(CleanType(type));
        }

        public static string CleanType(string type, bool keepPointer = false)
        {
            type = type
                .Split(new [] {"::"}, StringSplitOptions.RemoveEmptyEntries).Last()
                .Replace("const ", "")
                .Replace("&", "");

            if (!keepPointer)
                type = type.Replace("*", "");
            return type;
        }

        internal string EscapeVariableName(string name)
        {
            if (_illiegalVariableNames.Contains(name))
                return "@" + name;
            return name;
        }
    }

    public class CppClassContainer
    {
        public CppClassContainer(CppClass cppClass)
        {
            Functions = cppClass.Constructors.Concat(cppClass.Functions).ToList();
            Class = cppClass;
        }

        public CppClassContainer(IEnumerable<CppFunction> functions)
        {
            Functions = functions.ToList();
        }

        public bool IsGlobal => Class == null;

        public CppClass Class { get; }

        public string Name => Class?.GetDisplayName();

        public List<CppFunction> Functions { get; }
    }
}
