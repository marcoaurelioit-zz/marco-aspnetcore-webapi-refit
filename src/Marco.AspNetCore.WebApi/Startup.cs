using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Marco.AspNetCore.Adapter.SwApi;
using Marco.AspNetCore.WebApi.BootStrapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Marco.AspNetCore.WebApi
{
    public class Startup : ApiBootStrapper
    {
        protected override ApiInfo ApiInfo => new ApiInfo()
        {
            Name = "Marco API",
            Description = "API using refit.",
            DefaultVersion = "1.0"
        };

        static Startup()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<SwApiAdapterAutoMapperProfile>();
            });
        }

        public Startup(IConfiguration configuration)
         : base(configuration)
        {
        }

        [ExcludeFromCodeCoverage]
        protected override void AddCustomApiServices(IServiceCollection services)
        {
            services.AddSwApiAdapter(Configuration);
        }

        [ExcludeFromCodeCoverage]
        protected override void AddCustomMiddlewaresInPipeline(IApplicationBuilder app)
        {

        }
    }
}