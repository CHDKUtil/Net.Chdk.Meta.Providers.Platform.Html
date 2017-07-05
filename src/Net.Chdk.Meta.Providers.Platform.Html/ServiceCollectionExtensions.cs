using Microsoft.Extensions.DependencyInjection;
using Net.Chdk.Meta.Providers.CameraModel;

namespace Net.Chdk.Meta.Providers.Platform.Html
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHtmlPlatformProvider(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<IPlatformProvider, HtmlPlatformProvider>();
        }
    }
}
