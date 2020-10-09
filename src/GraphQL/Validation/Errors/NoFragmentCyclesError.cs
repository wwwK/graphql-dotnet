using System;
using GraphQL.Language.AST;

namespace GraphQL.Validation.Errors
{
    [Serializable]
    public class NoFragmentCyclesError : ValidationError
    {
        internal const string NUMBER = "5.5.2.2";

        public NoFragmentCyclesError(ValidationContext context, string fragName, string[] spreadNames, params INode[] nodes)
            : base(context.OriginalQuery, NUMBER, CycleErrorMessage(fragName, spreadNames), nodes)
        {
        }

        internal static string CycleErrorMessage(string fragName, string[] spreadNames)
        {
            var via = spreadNames.Length > 0 ? " via " + string.Join(", ", spreadNames) : "";
            return $"Cannot spread fragment \"{fragName}\" within itself{via}.";
        }
    }
}