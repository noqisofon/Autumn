using Autumn.Extensions;
using System;
using System.Text.RegularExpressions;

namespace Autumn.Core {

    /// <summary>
    ///
    /// </summary>
    public abstract class RegularExpressionCriteria : ICriteria {

        #region Protected Constructors

        /// <summary>
        ///
        /// </summary>
        protected RegularExpressionCriteria() : this( RegexOptions.IgnoreCase, MatchAnyThingPattern ) {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pattern"></param>
        protected RegularExpressionCriteria(string pattern) : this( RegexOptions.IgnoreCase, pattern ) {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="options"></param>
        /// <param name="parttern"></param>
        protected RegularExpressionCriteria(RegexOptions options, string pattern) {
            this.Options = options;
            this.Pattern = pattern;
        }

        #endregion Protected Constructors

        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public Regex Expression { get; set; }

        /// <summary>
        ///
        /// </summary>
        public RegexOptions Options { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Pattern {
            get => this.pattern;
            set {
                this.pattern = value.HasText()
                    ? value
                    : MatchAnyThingPattern;
                this.Expression = new Regex( this.Pattern, this.Options );
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="datum"></param>
        /// <returns></returns>
        public abstract bool IsSatisfied(object datum);

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected bool IsMatch(string name) {
            return this.Expression.IsMatch( name );
        }

        #endregion Protected Methods

        #region Protected Fields

        /// <summary>
        ///
        /// </summary>
        protected const string MatchAnyThingPattern = ".*";

        #endregion Protected Fields

        #region Private Fields

        /// <summary>
        ///
        /// </summary>
        private string pattern;

        #endregion Private Fields

    }
}