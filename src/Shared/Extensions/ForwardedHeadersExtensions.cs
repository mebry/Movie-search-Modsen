using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;

namespace Shared.Extensions
{
    public static class ForwardedHeadersExtensions
    {
        public static void ApplyForwardedHeaders(this IApplicationBuilder app)
        {
            var forwardedHeaders = new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            };

            app.UseForwardedHeaders(forwardedHeaders);
        }
    }
}
