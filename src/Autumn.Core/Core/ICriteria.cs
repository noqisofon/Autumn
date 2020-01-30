namespace Autumn.Core {

    /// <summary>
    ///
    /// </summary>
    public interface ICriteria {

        /// <summary>
        ///
        /// </summary>
        /// <param name="datum"></param>
        /// <returns></returns>
        bool IsSatisfied(object datum);
    }
}