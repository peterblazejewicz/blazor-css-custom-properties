using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace blazejewicz.CssCustomProperties.Services
{
    /// <summary>
    /// Defins access to CSS custom properties
    /// See: https://developer.mozilla.org/en-US/docs/Web/CSS/
    /// </summary>
    public interface ICustomProperties
    {
        /// <summary>
        /// Sets custom CSS property scoped to the element
        /// </summary>
        /// <param name="elementRef">Reference to the element</param>
        /// <param name="name">Name of the CSS custom property</param>
        /// <param name="value">Value of the custom property</param>
        /// <param name="priority">Optional prority of the custom property</param>
        ValueTask SetPropertyAsync(ElementReference elementRef, string name, string value, string priority = null);

        /// <summary>
        /// Sets custom CSS property to the element matching selector. The selector is run within the
        /// context of the document element, which equals to `document.querySelector(selector)` in native
        /// JavaScript
        /// </summary>
        /// <param name="selector">Selector to match element withs</param>
        /// <param name="name">Name of the CSS custom property</param>
        /// <param name="value">Value of the custom property</param>
        /// <param name="priority">Optional priority of the custom property</param>
        ValueTask SetPropertyAsync(string selector, string name, string value, string priority = null);

        /// <summary>
        /// Sets custom CSS property on the root scope, which equals to `:root` selector.
        /// </summary>
        /// <param name="name">Name of the CSS custom property</param>
        /// <param name="value">Value of the custom property</param>
        /// <param name="priority">Optional priority of the custom property</param>
        ValueTask SetRootPropertyAsync(string name, string value, string priority = null);

        /// <summary>
        /// Gets value of the custom CSS property scoped to the element.
        /// </summary>
        /// <param name="name">Name of the CSS custom property to retrieve</param>
        /// <returns>Value of the property as string or empty string</returns>
        ValueTask<string> GetPropertyValueAsync(ElementReference elementRef, string name);

        /// <summary>
        /// Gets value of the custom CSS propert scoped to the element matched by the
        /// selector. The selector is run within the context of the document element, which equals to
        /// `document.querySelector(selector)` in native JavaScript
        /// </summary>
        /// <param name="name">Name of the CSS custom property to retrieve</param>
        /// <returns>Value of the property as string or empty string</returns>
        ValueTask<string> GetPropertyValueAsync(string selector, string name);

        /// <summary>
        /// Gets value of the custom CSS propert scoped on the root scope, which equals to
        /// `:root` selector.
        /// </summary>
        /// <param name="name">Name of the CSS custom property to retrieve</param>
        /// <returns>Value of the property as string or empty string</returns>
        ValueTask<string> GetRootPropertyValueAsync(string name);

        /// <summary>
        /// Removes custom property from the element.
        /// </summary>
        /// <param name="elementRef">Reference to the element</param>
        /// <param name="name">Name of the CSS custom property</param>
        /// <returns>Value of removed property as string or empty string</returns>
        ValueTask<string> RemovePropertyAsync(ElementReference elementRef, string name);

        /// <summary>
        /// Removes custom property from the element matched by selector. The selector is run
        /// in the context of the document, which equals to `document.querySelector(selector)`.
        /// </summary>
        /// <param name="selector">Selector to match element withs</param>
        /// <param name="name">Name of the CSS custom property</param>
        /// <returns>Value of removed property as string or empty string</returns>
        ValueTask<string> RemovePropertyAsync(string selector, string name);

        /// <summary>
        /// Removes custom property from the root element.
        /// </summary>
        /// <param name="name">Name of the CSS custom property</param>
        /// <returns>Value of removed property as string or empty string</returns>
        ValueTask<string> RemoveRootPropertyAsync(string name);

    }
}
