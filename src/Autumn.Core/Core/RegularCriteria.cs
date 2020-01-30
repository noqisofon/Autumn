using Autumn.Extensions;

using System.Text.RegularExpressions;

namespace Autumn.Core {

    /// <summary>
    ///
    /// </summary>
    public abstract class RegularCriteria : ICriteria {

        #region Protected Constructors

        /// <summary>
        ///
        /// </summary>
        protected RegularCriteria() : this( RegexOptions.IgnoreCase, MatchAnyThingPattern ) {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pattern"></param>
        protected RegularCriteria(string pattern) : this( RegexOptions.IgnoreCase, pattern ) {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="options"></param>
        /// <param name="parttern"></param>
        protected RegularCriteria(RegexOptions options, string pattern) {
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