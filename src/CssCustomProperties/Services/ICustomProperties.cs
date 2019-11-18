using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace blazejewicz.CssCustomProperties.Services
{
    public interface ICustomProperties
    {
        ValueTask SetPropertyAsync(ElementReference elementRef, string name, string value, string priority = null);
        ValueTask SetPropertyAsync(string selector, string name, string value, string priority = null);

        ValueTask SetRootPropertyAsync(string name, string value, string priority = null);

        ValueTask<string> GetPropertyValueAsync(ElementReference elementRef, string name);

        ValueTask<string> GetPropertyValueAsync(string selector, string name);

        ValueTask<string> GetRootPropertyValueAsync(string name);

        ValueTask<string> RemovePropertyAsync(ElementReference elementRef, string name);

        ValueTask<string> RemovePropertyAsync(string selector, string name);

        ValueTask<string> RemoveRootPropertyAsync(string name);

    }
}
