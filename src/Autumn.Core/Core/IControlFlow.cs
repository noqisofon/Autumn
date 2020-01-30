using System;

namespace Autumn.Core {

    /// <summary>
    ///
    /// </summary>
    public interface IControlFlow {

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool Under(Type type);

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        bool Under(Type type, string methodName);

        /// <summary>
        ///
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        bool UnderToken(string token);

        #endregion Public Methods
    }
}