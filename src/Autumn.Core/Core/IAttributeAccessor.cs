namespace Autumn.Core {

    /// <summary>
    ///
    /// </summary>
    public interface IAttributeAccessor {

        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        string[] AttributeNames { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        object GetAttribute(string name);

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool HasAttribute(string name);

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        object RemoveAttribute(string name);

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        void SetAttribute(string name, object value);

        #endregion Public Methods
    }
}