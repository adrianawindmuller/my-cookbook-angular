using Microsoft.AspNetCore.Routing;

namespace MyCookbook.Api
{
    internal class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        public string TransformOutbound(object value) => value?.ToString().ToLower();
    }
}