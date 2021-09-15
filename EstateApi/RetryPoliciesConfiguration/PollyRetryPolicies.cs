using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System;

namespace EstateApi.RetryPoliciesConfiguration
{
    public static class PollyRetryPolicies
    {
        public static void AddRetryPolicies(this IHttpClientBuilder httpBuilder)
        {
            httpBuilder.SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(HttpPolicyExtensions
                                    .HandleTransientHttpError()
                                    .OrResult(x => x.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                                    .OrResult(x => (int)x.StatusCode >= 500)
                                    .WaitAndRetryAsync(10, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))));

        }
    }
}
