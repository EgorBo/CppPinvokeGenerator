using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CppPinvokeGenerator
{
    public static class StringExtensions
    {
        public static string AsCommaSeparated(this IEnumerable<object> obj) => string.Join(", ", obj);

        /// <summary>
        /// "snake_case" to "CamelCase"
        /// </summary>
        public static string ToCamelCase(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            return string.Join("", str.Split(new [] {"_"}, StringSplitOptions.RemoveEmptyEntries)
                .Select(b => char.ToUpperInvariant(b[0]) + b.Substring(1)));
        }

        public static string RemoveEnd(this string str, int count)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return str.Substring(0, str.Length - count);
        }

        public static StringBuilder RemoveEnd(this StringBuilder str, int count)
        {
            str.Remove(str.Length - count, count);
            return str;
        }

        public static string Tabify(this string str, int tabs) 
            => string.Join("\n", 
                str.Split('\n')
                    .Select(l => new string(' ', tabs * 4) + l));
    }
}
