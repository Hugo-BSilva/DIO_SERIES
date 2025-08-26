using DIO.Series.Application.Services;
using DIO.Series.ConsoleUI;
using DIO.Series.Infrastructure.Repository;
using DIO.Series.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    static void Main(string[] args)
    {
        using var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                // Repositório em memória: SINGLETON para manter o estado enquanto o app roda
                services.AddSingleton<ISerieRepository, SerieRepository>();

                // AppService e UI
                services.AddScoped<SerieAppService>();
                services.AddScoped<IConsole, ConsoleWrapper>();
                services.AddScoped<SerieConsoleApp>();
            })
            .Build();

        // Resolve o app e roda
        using var scope = host.Services.CreateScope();
        var app = host.Services.GetRequiredService<SerieConsoleApp>();
        app.Run();
    }
}