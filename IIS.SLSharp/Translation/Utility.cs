using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.CSharp;

namespace IIS.SLSharp.Translation
{
    static class Utility
    {
        public static StringBuilder ArgsToString(this ICollection<Expression> args, IAstVisitor<int, StringBuilder> visitor)
        {
            var result = new StringBuilder();
            if (args.Count <= 0)
                return result;

            foreach (var v in args.Take(args.Count - 1))
            {
                result.Append(v.AcceptVisitor(visitor, 0));
                result.Append(", ");
            }

            result.Append(args.Last().AcceptVisitor(visitor, 0));
            return result;
        }

    }
}
