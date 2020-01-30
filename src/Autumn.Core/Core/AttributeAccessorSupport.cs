using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Autumn.Core {

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public abstract class AttributeAccessorSupport : IAttributeAccessor {

        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public string[] AttributeNames => this.attributes.Keys.ToArray();

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(object other) {
            if ( this == other ) {
                return true;
            }

            if ( !( other is AttributeAccessorSupport ) ) {
                return false;
            }

            var that = other as AttributeAccessorSupport;

            return this.attributes.Equals( that.attributes );
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object GetAttribute(string name) {
            Trace.Assert( name != null, "Name must not be null" );

            if ( !this.attributes.ContainsKey( name ) ) {
                return null;
            }

            return this.attributes[name];
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => this.attributes.GetHashCode();

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool HasAttribute(string name) {
            Trace.Assert( name != null, "Name must not be null" );

            return this.attributes.ContainsKey( name );
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object RemoveAttribute(string name) {
            Trace.Assert( name != null, "Name must not be null" );

            if ( !this.attributes.ContainsKey( name ) ) {
                return false;
            }

            return this.attributes.Remove( name );
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public virtual void SetAttribute(string name, object value) {
            Trace.Assert( name != null, "Name must not be null" );

            if ( value != null ) {
                this.attributes.Add( name, value );
            } else {
                this.RemoveAttribute( name );
            }
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="source"></param>
        protected void CopyAttributesFrom(IAttributeAccessor source) {
            Trace.Assert( source != null, "Source must not be null" );

            var attribute_names = source.AttributeNames;
            foreach ( var attribute_name in attribute_names ) {
                this.SetAttribute( attribute_name, source.GetAttribute( attribute_name ) );
            }
        }

        #endregion Protected Methods

        #region Private Fields

        /// <summary>
        ///
        /// </summary>
        private readonly IDictionary<string, object > attributes = new Dictionary<string, object>();

        #endregion Private Fields
    }
}