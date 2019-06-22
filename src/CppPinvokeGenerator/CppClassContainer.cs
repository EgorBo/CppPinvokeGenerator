using System.Collections.Generic;
using System.Linq;
using CppAst;

namespace CppPinvokeGenerator
{
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
