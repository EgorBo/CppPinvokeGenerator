using System;
using System.Text;

namespace CppPinvokeGenerator
{
    /// <summary>
    /// Generic fluent interface to build a function (C or C#)
    /// </summary>
    public class FunctionWriter
    {
        private readonly StringBuilder _sb = new StringBuilder(200);
        private bool _isVoid;
        private int _bodyCalls;
        private int _definedParametersCount;
        private int _passedParametersCount;
        private bool _expressionBodySyntax;
        private bool _baseCtor;

        public FunctionWriter Attribute(string attribute)
        {
            _sb.AppendLine(attribute);
            return this;
        }

        public FunctionWriter Static()
        {
            _sb.Append("static ");
            return this;
        }

        public FunctionWriter Public()
        {
            _sb.Append("public ");
            return this;
        }

        public FunctionWriter Private()
        {
            _sb.Append("private ");
            return this;
        }

        public FunctionWriter Extern()
        {
            _sb.Append("extern ");
            return this;
        }

        public FunctionWriter ReturnType(string type, string wrapWith = null, int padding = 0)
        {
            int preLength = _sb.Length;
            if (wrapWith != null)
                _sb.Append(wrapWith).Append("(");

            _isVoid = type == "void" || type == null || type.Contains("(void)");
            if (type != null)
                _sb.Append(type);

            if (wrapWith != null)
                _sb.Append(")");

            if (type != null)
                _sb.Append(" ");

            var toPad = padding - (_sb.Length - preLength);
            if (toPad > 0)
                _sb.Append(new string(' ', toPad));

            return this;
        }

        public FunctionWriter BaseCtor(params string[] values)
        {
            _baseCtor = true;
            if (_definedParametersCount > 0)
                _sb.RemoveEnd(", ".Length);
            _sb.Append(") : base(" + string.Join(", ", values));
            return this;
        }

        public FunctionWriter MethodName(string methodName)
        {
            _sb.Append(methodName).Append("(");
            return this;
        }

        public FunctionWriter Parameter(string type, string name, string defaultValue = null)
        {
            _definedParametersCount++;
            _sb.Append($"{type} {name}");
            if (defaultValue != null)
                _sb.Append(" = ").Append(defaultValue);

            _sb.Append(", ");
            return this;
        }

        public string BuildWithoutBody()
        {
            if (_definedParametersCount > 0 && !_baseCtor)
                _sb.RemoveEnd(", ".Length);
            _sb.Append(");");
            return _sb.ToString();
        }

        public FunctionWriter StartExpressionBody()
        {
            _expressionBodySyntax = true;
            if (_definedParametersCount > 0 && !_baseCtor)
                _sb.RemoveEnd(", ".Length);
            _sb.Append(") => ");

            return this;
        }

        public FunctionWriter BodyStart()
        {
            if (_definedParametersCount > 0 && !_baseCtor)
                _sb.RemoveEnd(", ".Length);
            _sb.Append(") { ");

            if (!_isVoid)
                _sb.Append("return ");

            return this;
        }

        public FunctionWriter Body(string str)
        {
            _sb.Append(str);
            return this;
        }

        public FunctionWriter BodyCallMethod(string method)
        {
            _bodyCalls++;
            _sb.Append(method).Append("(");
            return this;
        }

        public FunctionWriter PassParameter(string parameter)
        {
            _passedParametersCount++;
            _sb.Append(parameter).Append(", ");
            return this;
        }

        public FunctionWriter EndLastCall(bool appendComma)
        {
            if (_passedParametersCount > 0)
                _sb.RemoveEnd(2);
            _passedParametersCount = 0;

            if (_bodyCalls > 0)
            {
                _sb.Append(")");
                _bodyCalls--;
            }
            if (appendComma)
                _sb.Append(", ");
            return this;
        }

        public string Build(string expression = null)
        {
            if (_passedParametersCount > 0)
                _sb.RemoveEnd(2);
            _passedParametersCount = 0;

            for (int i = 0; i < _bodyCalls; i++)
                _sb.Append(")");

            if (expression != null)
                _sb.Append(expression);

            _sb.Append(";");
            if (!_expressionBodySyntax)
                _sb.Append(" }");
            return _sb.ToString();
        }

        public FunctionWriter SummaryComment(string comments)
        {
            if (string.IsNullOrWhiteSpace(comments))
                return this;

            _sb.AppendLine("/// <summary>");

            if (!string.IsNullOrWhiteSpace(comments))
                foreach (var commentLine in comments.Split(new [] {"\n", "\r\n"}, StringSplitOptions.RemoveEmptyEntries))
                    _sb.Append("/// ").AppendLine(commentLine);

            _sb.AppendLine("/// </summary>");
            return this;
        }

        public FunctionWriter SimpleComment(string comments)
        {
            if (!string.IsNullOrWhiteSpace(comments))
                foreach (var commentLine in comments.Split('\n'))
                    _sb.Append("// ").AppendLine(commentLine);
            return this;
        }
    }
}
