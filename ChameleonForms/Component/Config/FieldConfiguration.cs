﻿using System;
using System.Collections.Generic;
using System.Web;
using ChameleonForms.Templates;

namespace ChameleonForms.Component.Config
{
    /// <summary>
    /// Holds configuration data for a form field.
    /// </summary>
    public interface IFieldConfiguration : IHtmlString
    {
        /// <summary>
        /// Attributes to add to the form element's HTML.
        /// </summary>
        HtmlAttributes Attributes { get; set; }

        /// <summary>
        /// Adds a CSS class (or a number of CSS classes) to the attributes.
        /// </summary>
        /// <param name="class">The CSS class(es) to add</param>
        /// <returns>The <see cref="IFieldConfiguration"/> to allow for method chaining</returns>
        IFieldConfiguration AddClass(string @class);

        /// <summary>
        /// Adds or updates a HTML attribute with a given value.
        /// </summary>
        /// <param name="key">The name of the HTML attribute to add/update</param>
        /// <param name="value">The value of the HTML attribute to add/update</param>
        /// <returns>The <see cref="IFieldConfiguration"/> to allow for method chaining</returns>
        IFieldConfiguration Attr(string key, object value);

        /// <summary>
        /// Adds or updates a HTML attribute with using a lambda method to express the attribute.
        /// </summary>
        /// <example>
        /// h.Attr(style => "width: 100%;")
        /// </example>
        /// <param name="attribute">A lambda expression representing the attribute to set and its value</param>
        /// <returns>The <see cref="IFieldConfiguration"/> to allow for method chaining</returns>
        IFieldConfiguration Attr(Func<object, object> attribute);

        /// <summary>
        /// Adds or updates a set of HTML attributes using lambda methods to express the attributes.
        /// </summary>
        /// <param name="attributes">A list of lambas where the lambda variable name is the name of the attribute and the value is the value</param>
        /// <returns>The <see cref="IFieldConfiguration"/> to allow for method chaining</returns>
        IFieldConfiguration Attrs(params Func<object, object>[] attributes);

        /// <summary>
        /// Adds or updates a set of HTML attributes using a dictionary to express the attributes.
        /// </summary>
        /// <param name="attributes">A dictionary of attributes</param>
        /// <returns>The <see cref="IFieldConfiguration"/> to allow for method chaining</returns>
        IFieldConfiguration Attrs(IDictionary<string, object> attributes);

        /// <summary>
        /// Adds or updates a set of HTML attributes using anonymous objects to express the attributes.
        /// </summary>
        /// <param name="attributes">An anonymous object of attributes</param>
        /// <returns>The <see cref="IFieldConfiguration"/> to allow for method chaining</returns>
        IFieldConfiguration Attrs(object attributes);

        /// <summary>
        /// Sets the field that the field configuration is wrapping so that
        ///     a call to ToHtmlString() will output the given field.
        /// </summary>
        /// <param name="field">The field being configured</param>
        void SetField(IHtmlString field);
    }

    /// <summary>
    /// Holds configuration data for a form field.
    /// </summary>
    public class FieldConfiguration : IFieldConfiguration
    {
        private IHtmlString _field;

        /// <summary>
        /// Constructs a field configuration.
        /// </summary>
        public FieldConfiguration()
        {
            Attributes = new HtmlAttributes();
        }

        public HtmlAttributes Attributes { get; set; }

        public IFieldConfiguration AddClass(string @class)
        {
            Attributes.AddClass(@class);
            return this;
        }

        public IFieldConfiguration Attr(string key, object value)
        {
            Attributes.Attr(key, value);
            return this;
        }

        public IFieldConfiguration Attr(Func<object, object> attribute)
        {
            Attributes.Attr(attribute);
            return this;
        }

        public IFieldConfiguration Attrs(params Func<object, object>[] attributes)
        {
            Attributes.Attrs(attributes);
            return this;
        }

        public IFieldConfiguration Attrs(IDictionary<string, object> attributes)
        {
            Attributes.Attrs(attributes);
            return this;
        }

        public IFieldConfiguration Attrs(object attributes)
        {
            Attributes.Attrs(attributes);
            return this;
        }

        public void SetField(IHtmlString field)
        {
            _field = field;
        }

        public string ToHtmlString()
        {
            return _field.ToHtmlString();
        }
    }
}
