using Autumn.Extensions;

using System.Text.RegularExpressions;
using System.Reflection;

namespace Autumn.Core {

    /// <summary>
    ///
    /// </summary>
    public class RegularExpressionMethodNameCriteria : RegularExpressionCriteria {

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
            var method = datum as MethodInfo;
            if ( method == null ) {
                return false;
            }

            return base.IsMatch( method.Name );
        }

        /// <summary>
        ///
        /// </summary>
        private const string MatchAnyMethodNamePattern = ".+";
    }
}