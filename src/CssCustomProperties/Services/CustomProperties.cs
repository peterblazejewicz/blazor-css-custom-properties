using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace blazejewicz.CssCustomProperties.Services
{
    public class CustomProperties : ICustomProperties
    {
        private const string apiPrefix = "blazejewicz.cssPropertiesSupport";

        private readonly IJSRuntime JSRuntime;

        public CustomProperties(IJSRuntime JSRuntime)
        {
            this.JSRuntime = JSRuntime;
        }

        public async ValueTask<string> GetPropertyValueAsync(ElementReference elementRef, string name)
        {
            const string methodName = "getPropertyValue";
            return await JSRuntime.InvokeAsync<string>($"{apiPrefix}.{methodName}", elementRef, name);
        }

        public async ValueTask<string> GetPropertyValueAsync(string selector, string name)
        {
            const string methodName = "getPropertyValueWithSelector";
            return await JSRuntime.InvokeAsync<string>($"{apiPrefix}.{methodName}", selector, name);
        }

        public async ValueTask<string> GetRootPropertyValueAsync(string name)
        {
            const string methodName = "getRootPropertyValue";
            return await JSRuntime.InvokeAsync<string>($"{apiPrefix}.{methodName}", name);
        }

        public async ValueTask<string> RemovePropertyAsync(ElementReference elementRef, string name)
        {
            const string methodName = "removeProperty";
            return await JSRuntime.InvokeAsync<string>($"{apiPrefix}.{methodName}", elementRef, name);
        }

        public async ValueTask<string> RemovePropertyAsync(string selector, string name)
        {
            const string methodName = "removePropertyWithSelector";
            return await JSRuntime.InvokeAsync<string>($"{apiPrefix}.{methodName}", selector, name);
        }

        public async ValueTask<string> RemoveRootPropertyAsync(string name)
        {
            const string methodName = "removeRootProperty";
            return await JSRuntime.InvokeAsync<string>($"{apiPrefix}.{methodName}", name);
        }

        public ValueTask SetPropertyAsync(ElementReference elementRef, string name, string value, string priority = null)
        {
            const string methodName = "setProperty";

            return JSRuntime.InvokeVoidAsync($"{apiPrefix}.{methodName}", elementRef, name, value, priority);
        }

        public ValueTask SetPropertyAsync(string selector, string name, string value, string priority = null)
        {
            const string methodName = "setPropertyWithSelector";
            return JSRuntime.InvokeVoidAsync($"{apiPrefix}.{methodName}", selector, name, value, priority);
        }

        public ValueTask SetRootPropertyAsync(string name, string value, string priority = null)
        {
            const string methodName = "setRootProperty";
            return JSRuntime.InvokeVoidAsync($"{apiPrefix}.{methodName}", name, value, priority);
        }
    }
}
