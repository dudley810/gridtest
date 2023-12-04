using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using Blazored.Toast;

namespace GridTest.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddRadzenComponents();

            builder.Services.AddBlazoredToast();

            await builder.Build().RunAsync();
        }
    }
}
