using System.Collections.Generic;

namespace Autumn.Core {

    /// <summary>
    ///
    /// </summary>
    public class ComposedCriteria : ICriteria {

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        public ComposedCriteria() : this( null ) {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="criteria"></param>
        public ComposedCriteria(ICriteria criteria) {
            this.Criteria = new List<ICriteria>();

            this.Add( criteria );
        }

        #endregion Public Constructors

        #region Protected Properties

        /// <summary>
        ///
        /// </summary>
        protected IList<ICriteria> Criteria { get; }

        #endregion Protected Properties

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="criteria"></param>
        public void Add(ICriteria criteria) {
            if ( criteria != null ) {
                this.Criteria.Add( criteria );
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="datum"></param>
        /// <returns></returns>
        public bool IsSatisfied(object datum) {
            foreach ( var criteria in this.Criteria ) {
                if ( !criteria.IsSatisfied( datum ) ) {
                    return false;
                }
            }

            return true;
        }

        #endregion Public Methods
    }
}