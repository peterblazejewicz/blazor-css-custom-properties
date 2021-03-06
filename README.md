# CssCustomProperties

Access interface to CSS custom properties from Blazor.
Please read more about the CSS custom properties in this article:

https://developer.mozilla.org/en-US/docs/Web/CSS/--*

![image](https://user-images.githubusercontent.com/14539/69192034-0e029580-0b24-11ea-8e28-c8292aa6cd38.png)

## Usage

After installing the package as dependency, simply:

- register `CssCustomProperties` for use by the DI

```cs
public void ConfigureServices(IServiceCollection services)
{
    services.AddCssCustomProperties();
}
```

- request from DI, for example using `@inject` attribute:

```cs
@page "/"
@using blazejewicz.CssCustomProperties.Services

@inject ICustomProperties CustomProperties
```

### Using `ElementReference`

```cs
// set property
this.CustomProperties.SetPropertyValueAsync(elementRef, propertyName, value);
// get property
var color = await this.CustomProperties.GetPropertyValueASync(elementRef, propertyName);
// remove property
var oldColor = await this.CustomProperties.RemovePropertyAsync(elementRef, propertyName);
```

### Using `selector`

Using the selector matches element in the context of the page document, so:

```js
const element = document.querySelector(selector);
```

```cs
// set property
this.CustomProperties.SetPropertyValueAsync(".my-element", propertyName, value);
// get property
var color = await this.CustomProperties.GetPropertyValueASync(".my-element", propertyName);
// remove property
var oldColor = await this.CustomProperties.RemovePropertyAsync(".my-element", propertyName);
```

### Using `:root` scope

```cs
// set property
this.CustomProperties.SetRootPropertyValueAsync(propertyName, value);
// get property
var color = await this.CustomProperties.GetRootPropertyValueAsync(propertyName);
// remove property
var oldColor = await this.CustomProperties.RemoveRootPropertyAsync(propertyName);
```

## License

MIT

## Author

@peterblazejewicz