using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CppAst;

namespace CppPinvokeGenerator
{
    internal class PropertyGenerator
    {
        private readonly List<PropertyInfo> _candidates = new List<PropertyInfo>();

        public void RegisterCandidates(TypeMapper mapper, List<CppFunction> functions)
        {
            string[] prefixes = {"Is", "Has", "Get"};
            foreach (var f in functions)
            {
                var pi = new PropertyInfo(mapper);
                string name = mapper.RenameForApi(f.Name, true);
                string prefix = prefixes.FirstOrDefault(p => name.StartsWith(p));
                if (prefix != null)
                {
                    if (f.Parameters.Count == 0 && !f.IsConstructor)
                    {
                        pi.GetterFunction = f;
                        pi.GettetApiName = name;
                        pi.PropertyName = name.Remove(0, prefix.Length);

                        // looking for setter:
                        CppFunction setter = functions.FirstOrDefault(sf => sf.Parameters.Count == 1 && mapper.RenameForApi(sf.Name, true).StartsWith("Set"));
                        if (setter != null && f.IsStatic() == setter.IsStatic() && !setter.IsConstructor)
                        {
                            pi.SetterFunction = setter;
                            pi.SetterApiName = mapper.RenameForApi(setter.Name, true);
                        }
                    }
                }

                _candidates.Add(pi);
            }
        }

        public PropertyInfo AsPropertyCandidate(CppFunction function)
        {
            return _candidates.FirstOrDefault(c => c.GetterFunction == function || c.SetterFunction == function);
        }
    }

    public class PropertyInfo
    {
        private readonly TypeMapper _mapper;
        public PropertyInfo(TypeMapper mapper) => _mapper = mapper;
        public CppFunction GetterFunction { get; set; }
        public CppFunction SetterFunction { get; set; }
        public string PropertyName { get; set; }
        public string GettetApiName { get; set; }
        public string SetterApiName { get; set; }

        public string GenerateProperty()
        {
            // TODO: use FunctionWriter here
            // TODO: comments
            string type = _mapper.MapToManagedApiType(GetterFunction.ReturnType);
            string modifier = GetterFunction.IsStatic() ? "static " : "";
            if (SetterFunction == null)
                return $"public {modifier}{type} {PropertyName} => {GettetApiName}();\n";
            return $"public {modifier}{type} {PropertyName}\n{{\n    get => {GettetApiName}();\n    set => {SetterApiName}(value);\n}}\n";
        }
    }
}
