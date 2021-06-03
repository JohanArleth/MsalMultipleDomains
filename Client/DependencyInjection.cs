using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Client
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMsalAuthentication(options =>
            {
                configuration.Bind("AzureAd", options.ProviderOptions.Authentication);

                var scope = configuration.GetValue<string>("ApiScope");

                Console.WriteLine(scope);

                options.ProviderOptions.DefaultAccessTokenScopes.Add(scope);

                options.ProviderOptions.Cache.CacheLocation = "localStorage";
            });

            return services;
        }
    }
}