using Marco.AspNetCore.Adapter.SwApi;
using Marco.AspNetCore.Adapter.SwApi.Clients;
using Marco.AspNetCore.Domain.Adapters;
using Marco.Http.Client.Abstractions;
using Microsoft.Extensions.Configuration;
using Refit;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SwApiServiceCollectionExtensions
    {
        public static IServiceCollection AddSwApiAdapter(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            var swApiAdapterConfiguration = configuration.GetSection(nameof(SwApiAdapterConfiguration))
                                                         .TryGet<SwApiAdapterConfiguration>() ??
                                                            throw new ArgumentNullException(nameof(SwApiAdapterConfiguration));

            services.AddSingleton(swApiAdapterConfiguration);

            services.AddScoped(serviceProvider =>
            {              
                var httpClientFactory = serviceProvider.GetService<IMarcoHttpClientFactory>();
                var httpClient = httpClientFactory.Create();
                httpClient.BaseAddress = new Uri(swApiAdapterConfiguration.SwApiUrlBase);
                return RestService.For<IPeopleClient>(httpClient);
            });

            services.AddScoped<IPeopleAdapter, SwApiPeopleAdapter>();

            return services;
        }
    }
}