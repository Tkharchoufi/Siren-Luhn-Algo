using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SirenApp;
using SirenApp.Services.Crypto;
using SirenApp.Services.Siren;

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    services.GetRequiredService<App>().Run(args);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


try
{
    services.GetRequiredService<App>().Run(args);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


IHostBuilder CreateHostBuilder(string[] strings)
{
    return Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            services.AddTransient<ISirenService, SirenService>();
            services.AddTransient<ILuhnAlgoService, LuhnAlgoService>();
            services.AddSingleton<App>();
        });
}
