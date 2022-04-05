using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationsConflicts
{
  public class Program
  {
    public static readonly string Namespace = typeof(Program).Namespace;
    public static readonly string AppName = Namespace.Substring(Namespace.LastIndexOf('.', Namespace.LastIndexOf('.') - 1) + 1);
    public static async Task Main(string[] args)
    {
      IConfiguration configurations = new ConfigurationBuilder().
        AddJsonFile("appsettings.json")
        .Build();
      Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configurations)
        .CreateLogger();

      Log.Information("Application starting");
      try
      {
        Log.Information("Configuring web host ({ApplicationContext})...", AppName);
        Log.Information("Starting web host ({ApplicationContext})...", AppName);
        var host = CreateHostBuilder(args).Build();

        //await ApplyDbMigrationsWithDataSeedAsync(configurations, host);

        Log.Information("Starting web host ({ApplicationContext})...", AppName);
        host.Run();
      }
      catch (Exception ex)
      {
        Log.Fatal(ex, "Program terminated unexpectedly ({ApplicationContext})!", AppName);
      }
      finally
      {
        Log.CloseAndFlush();
      }
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
      return Host.CreateDefaultBuilder(args)
        .UseSerilog()
        .ConfigureWebHostDefaults(webBuilder =>
        {
          webBuilder.UseStartup<Startup>();
        });
    }
  }
}
