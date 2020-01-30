namespace Autumn.Extensions {

    /// <summary>
    ///
    /// </summary>
    public static class StringExtensions {

        /// <summary>
        ///
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool HasText(this string self) => !string.IsNullOrEmpty( self );
    }
}