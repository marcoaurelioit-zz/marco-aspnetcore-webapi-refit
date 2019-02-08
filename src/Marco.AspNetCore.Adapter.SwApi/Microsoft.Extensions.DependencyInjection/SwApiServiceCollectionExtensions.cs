using Marco.AspNetCore.Adapter.SwApi;
using Marco.AspNetCore.Adapter.SwApi.Clients;
using Marco.AspNetCore.Domain.Adapters;
using Microsoft.Extensions.Configuration;
using Refit;
using System;
using System.Net.Http;

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
                //TODO: Factory para HttpClient em desenvolvimento em breve este projeto será atualizado.

                var httpClient = new HttpClient()
                {
                    BaseAddress = new Uri(swApiAdapterConfiguration.SwApiUrlBase)
                };

                return RestService.For<IPeopleClient>(httpClient);
            });

            services.AddScoped<IPeopleAdapter, SwApiPeopleAdapter>();

            return services;
        }
    }
}