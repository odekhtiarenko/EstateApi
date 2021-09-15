using EstateApi.AutoMapperProfile;
using EstateApi.Handlers.QueryHandlers;
using EstateApi.RetryPoliciesConfiguration;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Secret3dParty.ApiClient;
using Secret3dParty.ApiClient.Abstraction;
using Secret3dParty.ApiClient.Configuration;
using System;

namespace EstateApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMediatR(typeof(GetTopActiveRealEstateAgentsQueryHandler).Assembly);
            services.AddAutoMapper(typeof(MapperProfile));

            var options = Configuration.GetSection("ApiClientConfiguration")
                                                    .Get<ApiClientConfiguration>();


            services.AddHttpClient(ApiClientConfiguration.Secret3dPartyClientName, c =>
            {
                c.BaseAddress = new Uri($"{options.BaseUrl}/{options.ApiKey}/");
            }).AddRetryPolicies();

            services.AddTransient<ISecret3dPartyHttpClient, Secret3dPartyHttpClient>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EstateApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EstateApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
