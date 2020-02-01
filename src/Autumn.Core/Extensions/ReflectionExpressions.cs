using System;
using System.Collections.Generic;
using System.Linq;

namespace Autumn.Extensions {

    /// <summary>
    ///
    /// </summary>
    public static class ReflectionExpressions {

        /// <summary>
        ///
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetTypes(this IEnumerable<object> self) {
            if ( self == null || !self.Any() ) {
                return Type.EmptyTypes;
            }

            return self.Select( arg => arg == null ? typeof( object ) : arg.GetType() );
        }
    }
}