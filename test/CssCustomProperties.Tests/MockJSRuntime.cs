using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CssCustomProperties.Tests
{
    public class MockJSRuntime : IJSRuntime
    {
        public List<(string Identifier, object[] Args)> Invocations { get; }
             = new List<(string Identifier, object[] Args)>();

        public object NextInvocationResult { get; set; }

        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object[] args)
        {
            Invocations.Add((identifier, args));
            return (ValueTask<TValue>)NextInvocationResult;
        }

        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object[] args)
            => InvokeAsync<TValue>(identifier, cancellationToken: CancellationToken.None, args: args);
    }
}
