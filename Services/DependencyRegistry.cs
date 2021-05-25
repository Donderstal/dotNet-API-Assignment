using Microsoft.Extensions.DependencyInjection;

namespace XLSXReaderAPI.Services {
    public static class DependencyRegistry {
        public static IServiceCollection InitializeServices(this IServiceCollection services) 
        {
            services.AddSingleton<XLSXReader>( );
            return services;
        }
    }
}
