using Autumn.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Autumn.Core {

    /// <summary>
    ///
    /// </summary>
    public class MethodArgumentsCriteria : ICriteria {

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        public MethodArgumentsCriteria() : this( ObjectExpressions.EmptyObjects ) {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arguments"></param>
        public MethodArgumentsCriteria(IEnumerable<object> arguments) {
            this.parameters = arguments.GetTypes();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="datum"></param>
        /// <returns></returns>
        public bool IsSatisfied(object datum) {
            var method = datum as MethodInfo;
            if ( method == null ) {
                return false;
            }

            var is_param_array   = false;
            var param_array_type = default(Type);

            var parameters_begin_checked = method.GetParameters();
            if ( parameters_begin_checked.Any() ) {
                var last_parameter              = parameters_begin_checked.Last();
                var param_array_attributes      = last_parameter.GetCustomAttributes<ParamArrayAttribute>( false );

                is_param_array = param_array_attributes.Any();
                if ( is_param_array ) {
                    param_array_type = last_parameter.ParameterType.GetElementType();
                }
            }

            var satisfied = false;
            if ( parameters_begin_checked.Length == this.parameters.Count() ) {
                satisfied = true;

                var i = 0;
                foreach ( var pair in this.parameters.Zip( parameters_begin_checked ) ) {
                    var source_type        = pair.First;
                    var type_begin_checked = pair.Second.ParameterType;

                    if ( !type_begin_checked.IsAssignableFrom( source_type ) ) {
                        if ( is_param_array && i == this.parameters.Count() - 1 ) {
                            if ( !param_array_type.IsAssignableFrom( source_type ) ) {
                                satisfied = false;

                                break;
                            }
                        } else {
                            satisfied = false;

                            break;
                        }
                    }

                    ++i;
                }
            } else if ( is_param_array && ( this.parameters.Count() >= parameters_begin_checked.Count() - 1 ) ) {
                satisfied = true;

                var i = 0;
                foreach ( var unused in parameters_begin_checked ) {
                    var source_type = this.parameters.ElementAt( i );

                    if ( !param_array_type.IsAssignableFrom( source_type ) ) {
                        satisfied = false;
                        break;
                    }

                    ++i;
                }
            }

            return satisfied;
        }

        #endregion Public Methods

        #region Private Fields

        /// <summary>
        /// 
        /// </summary>
        private readonly IEnumerable<Type> parameters;

        #endregion Private Fields
    }
}