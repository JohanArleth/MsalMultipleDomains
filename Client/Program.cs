using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System;
using System.Threading.Tasks;

namespace Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            var configuration = builder.Configuration;

            builder.Services.ConfigureAuthentication(configuration);

            await builder.Build().RunAsync();
        }
    }
}