using Autumn.Extensions;

using System.Text.RegularExpressions;

namespace Autumn.Core {

    /// <summary>
    ///
    /// </summary>
    public class RegularExpressionMethodNameCriteria : RegularCriteria {

        /// <summary>
        ///
        /// </summary>
        public RegularExpressionMethodNameCriteria() : this( MatchAnyMethodNamePattern ) {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="methodNamePattern"></param>
        public RegularExpressionMethodNameCriteria(string methodNamePattern) : base( RegexOptions.IgnoreCase, methodNamePattern.HasText()
                ? methodNamePattern
                : MatchAnyMethodNamePattern ) {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="datum"></param>
        /// <returns></returns>
        public override bool IsSatisfied(object datum) {
            throw new System.NotImplementedException();
        }

        /// <summary>
        ///
        /// </summary>
        private const string MatchAnyMethodNamePattern = ".+";
    }
}