using System;
using System.Diagnostics;
using System.Reflection;

namespace Autumn.Core {

    /// <summary>
    ///
    /// </summary>
    public abstract class ControlFlowFactory {

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static IControlFlow CreateControlFlow() => new DefaultControlFlow();

        #endregion Public Methods

        #region Private Classes

        /// <summary>
        ///
        /// </summary>
        private class DefaultControlFlow : IControlFlow {

            #region Public Constructors

            /// <summary>
            ///
            /// </summary>
            public DefaultControlFlow() {
                this.stack_trace = new StackTrace();
            }

            #endregion Public Constructors

            #region Public Methods

            bool IControlFlow.Under(Type type) => this.IsMatch( new MethodsDeclaredTypeCriteria( type ) );

            bool IControlFlow.Under(Type type, string methodName) {
                var criteria = new ComposedCriteria();

                criteria.Add( new MethodsDeclaredTypeCriteria( type ) );
                criteria.Add( new RegularExpressionMethodNameCriteria( methodName ) );

                return this.IsMatch( criteria );
            }

            bool IControlFlow.UnderToken(string token) => this.stack_trace.ToString().IndexOf( token ) != -1;

            #endregion Public Methods

            #region Private Methods

            private bool IsMatch(ICriteria criteria) {
                for ( var i = 0; i < this.stack_trace.FrameCount; ++i ) {
                    var method = this.stack_trace.GetFrame(i).GetMethod();

                    if ( criteria.IsSatisfied( method ) ) {
                        return true;
                    }
                }

                return false;
            }

            #endregion Private Methods

            #region Private Fields

            private readonly StackTrace stack_trace;

            #endregion Private Fields
        }

        private class MethodsDeclaredTypeCriteria : ICriteria {

            #region Public Constructors

            public MethodsDeclaredTypeCriteria(Type type) {
                this.type_to_match = type;
            }

            #endregion Public Constructors

            #region Public Methods

            public bool IsSatisfied(object datum) {
                var method = datum as MethodBase;
                if ( method != null && method.DeclaringType != null ) {
                    return method.DeclaringType.Equals( this.type_to_match );
                }

                return false;
            }

            #endregion Public Methods

            #region Private Fields

            private readonly Type type_to_match;

            #endregion Private Fields
        }

        #endregion Private Classes
    }
}