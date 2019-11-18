using blazejewicz.CssCustomProperties.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CssCustomProperties.Tests
{
    public class CustomPropertiesTests
    {
        [Fact]
        public void CustomProperties_Ctor()
        {
            // Arrange
            var interop = new MockJSRuntime();

            // Act/Assert
            var sut = new CustomProperties(interop);
            Assert.NotNull(sut);
        }

        [Theory]
        [InlineData("--blue", "#007bff")]
        [InlineData("--red", "#c00c00", "!important")]
        public async Task SetPropertyAsync_WithELementReference_CallsInterop(string propertyName, string propertyValue, string priority = null)
        {
            // Arrange
            var elementRef = new ElementReference();
            var jsInterop = new MockJSRuntime();
            var jsResultValueTask = new ValueTask<object>((object)null);
            jsInterop.NextInvocationResult = jsResultValueTask;
            var sut = new CustomProperties(jsInterop);

            // Act
            await sut.SetPropertyAsync(elementRef, propertyName, propertyValue, priority);

            // Assert
            var (Identifier, Args) = jsInterop.Invocations.Single();
            Assert.Equal($"{apiPrefix}.setProperty", Identifier);
            Assert.Collection(
                Args,
                arg => Assert.Equal(elementRef, arg),
                arg => Assert.Equal(propertyName, arg),
                arg => Assert.Equal(propertyValue, arg),
                arg => Assert.Equal(priority, arg)
                );
        }

        [Theory]
        [InlineData("#element-id", "--blue", "#007bff")]
        [InlineData(".some-element-selector", "--red", "#c00c00", "!important")]
        public async Task SetPropertyAsync_WithSelector_CallsInterop(string selector, string name, string value, string priority = null)
        {
            // Arrange
            var jsInterop = new MockJSRuntime();
            var jsResultValueTask = new ValueTask<object>();
            jsInterop.NextInvocationResult = jsResultValueTask;
            var sut = new CustomProperties(jsInterop);

            // Act
            await sut.SetPropertyAsync(selector, name, value, priority);

            // Assert
            var (Identifier, Args) = jsInterop.Invocations.Single();
            Assert.Equal($"{apiPrefix}.setPropertyWithSelector", Identifier);
            Assert.Collection(
                Args,
                arg => Assert.Equal(selector, arg),
                arg => Assert.Equal(name, arg),
                arg => Assert.Equal(value, arg),
                arg => Assert.Equal(priority, arg)
                );
        }

        [Theory]
        [InlineData("--blue", "#007bff")]
        [InlineData("--red", "#c00c00", "!important")]
        public async Task SetRootPropertyASync_CallsInterop(string name, string value, string priority = null)
        {
            // Arrange
            var jsInterop = new MockJSRuntime();
            var jsResultValueTask = new ValueTask<object>();
            jsInterop.NextInvocationResult = jsResultValueTask;
            var sut = new CustomProperties(jsInterop);

            // Act
            await sut.SetRootPropertyAsync(name, value, priority);

            // Assert
            var (Identifier, Args) = jsInterop.Invocations.Single();
            Assert.Equal($"{apiPrefix}.setRootProperty", Identifier);
            Assert.Collection(
                Args,
                arg => Assert.Equal(name, arg),
                arg => Assert.Equal(value, arg),
                arg => Assert.Equal(priority, arg));
        }

        [Theory]
        [InlineData("--blue", "#007bff")]
        [InlineData("--red", "red")]
        public async Task GetPropertyValueAsync_ReturnsExpectedValue(string name, string value)
        {
            // Arrange
            var elementRef = new ElementReference();
            var jsInterop = new MockJSRuntime();
            var jsResultValueTask = new ValueTask<string>(value);
            jsInterop.NextInvocationResult = jsResultValueTask;
            var sut = new CustomProperties(jsInterop);

            // Act
            var result = await sut.GetPropertyValueAsync(elementRef, name);

            // Assert
            var (Identifier, Args) = jsInterop.Invocations.Single();
            Assert.Equal($"{apiPrefix}.getPropertyValue", Identifier);
            Assert.Collection(
                Args,
                arg => Assert.Equal(elementRef, arg),
                arg => Assert.Equal(name, arg));
            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData("#element-selector", "--blue", "#007bff")]
        [InlineData(".element-selector", "--red", "red")]
        public async Task GetPropertyValueAsync_WithSelector_CallsInterop(string selector, string name, string value)
        {
            // Arrange
            var jsInterop = new MockJSRuntime();
            var jsResultValueTask = new ValueTask<string>(value);
            jsInterop.NextInvocationResult = jsResultValueTask;
            var sut = new CustomProperties(jsInterop);

            // Act
            var result = await sut.GetPropertyValueAsync(selector, name);

            // Assert
            var (Identifier, Args) = jsInterop.Invocations.Single();
            Assert.Equal($"{apiPrefix}.getPropertyValueWithSelector", Identifier);
            Assert.Collection(
                Args,
                arg => Assert.Equal(selector, arg),
                arg => Assert.Equal(name, arg));
            Assert.Equal(value, result);
        }

        const string apiPrefix = "blazejewicz.cssPropertiesSupport";

        [Theory]
        [InlineData("--blue", "#007bff")]
        [InlineData("--red", "red")]
        public async Task GetRootPropertyValueASync_CallsInterop(string name, string value)
        {
            // Arrange
            var jsInterop = new MockJSRuntime();
            var jsResultValueTask = new ValueTask<string>(value);
            jsInterop.NextInvocationResult = jsResultValueTask;
            var sut = new CustomProperties(jsInterop);

            // Act
            var result = await sut.GetRootPropertyValueAsync(name);

            // Assert
            var (Identifier, Args) = jsInterop.Invocations.Single();
            Assert.Equal($"{apiPrefix}.getRootPropertyValue", Identifier);
            Assert.Collection(
                Args,
                arg => Assert.Equal(name, arg));
            Assert.Equal(result, value);
        }

        [Theory]
        [InlineData("--blue", "#007bff")]
        [InlineData("--red", "red")]
        public async Task RemovePropertyAsync_CallsInterop(string name, string value)
        {
            // Arrange
            ElementReference elementRef = new ElementReference();
            var jsInterop = new MockJSRuntime();
            var jsResultValueTask = new ValueTask<string>(value);
            jsInterop.NextInvocationResult = jsResultValueTask;
            var sut = new CustomProperties(jsInterop);

            // Act
            var result = await sut.RemovePropertyAsync(elementRef, name);

            // Assert
            var (Identifier, Args) = jsInterop.Invocations.Single();
            Assert.Equal($"{apiPrefix}.removeProperty", Identifier);
            Assert.Collection(
                Args,
                arg => Assert.Equal(elementRef, arg),
                arg => Assert.Equal(name, arg));
            Assert.Equal(result, value);
        }

        [Theory]
        [InlineData("#element-id", "--blue", "#007bff")]
        [InlineData(".element-class", "--red", "red")]
        public async Task RemovePropertyAsync_WithSelector_CallsInterop(string selector, string name, string value)
        {
            // Arrange
            var jsInterop = new MockJSRuntime();
            var jsResultValueTask = new ValueTask<string>(value);
            jsInterop.NextInvocationResult = jsResultValueTask;
            var sut = new CustomProperties(jsInterop);

            // Act
            var result = await sut.RemovePropertyAsync(selector, name);

            // Assert
            var (Identifier, Args) = jsInterop.Invocations.Single();
            Assert.Equal($"{apiPrefix}.removePropertyWithSelector", Identifier);
            Assert.Collection(
                Args,
                arg => Assert.Equal(selector, arg),
                arg => Assert.Equal(name, arg));
            Assert.Equal(result, value);
        }

        [Theory]
        [InlineData("--blue", "#007bff")]
        [InlineData("--red", "red")]
        public async Task RemoveRootProperty_CallsInterop(string name, string value)
        {
            // Arrange
            var jsInterop = new MockJSRuntime();
            var jsResultValueTask = new ValueTask<string>(value);
            jsInterop.NextInvocationResult = jsResultValueTask;
            var sut = new CustomProperties(jsInterop);

            // Act
            var result = await sut.RemoveRootPropertyAsync(name);

            // Assert
            var (Identifier, Args) = jsInterop.Invocations.Single();
            Assert.Equal($"{apiPrefix}.removeRootProperty", Identifier);
            Assert.Collection(
                Args,
                arg => Assert.Equal(name, arg));
            Assert.Equal(result, value);
        }


    }


}

