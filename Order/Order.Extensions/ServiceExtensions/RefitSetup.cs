using DotNetCore.CAP;
using DotNetCore.CAP.Messages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Order;
using Order.Common;
using Order.Common.DB;
using Refit;

namespace Order.Extensions.ServiceExtensions;

public static class RefitSetup
{
    /// <summary>
    /// 统一注册CAP
    /// </summary>
    /// <param name="services"></param>
    public static void AddRefitSetup(this IServiceCollection services, Action<CapOptions> configure = null)
    {
        services.AddRefitClient<IWebApi>(settings)
        .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.example.com"));
        // Add additional IHttpClientBuilder chained methods as required here:
        // .AddHttpMessageHandler<MyHandler>()
        // .SetHandlerLifetime(TimeSpan.FromMinutes(2));

        // or injected from the container
        services.AddRefitClient<IWebApi>(provider => new RefitSettings() { /* configure settings */ })
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.example.com"));
        // Add additional IHttpClientBuilder chained methods as required here:
        // .AddHttpMessageHandler<MyHandler>()
        // .SetHandlerLifetime(TimeSpan.FromMinutes(2));
    }
}