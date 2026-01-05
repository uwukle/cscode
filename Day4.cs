#:package Microsoft.Extensions.Hosting@*

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

static string GetConfigurationPath() =>
    Path.Combine(Directory.GetCurrentDirectory(), "Day4.json");

static void ConfigureHostConfiguration(IConfigurationBuilder builder) =>
    builder.AddJsonFile(GetConfigurationPath());

static void ConfigureServices(HostBuilderContext context, IServiceCollection services) =>
    services.AddHostedService<HelloService>()
        .Configure<HelloOptions>(options =>
            options.Name = context.Configuration["Name"] ?? "noname");

await Host.CreateDefaultBuilder()
    .ConfigureHostConfiguration(ConfigureHostConfiguration)
    .ConfigureServices(ConfigureServices)
    .Build()
    .RunAsync();

sealed class HelloOptions
{
    public string Name { get; set; } = string.Empty;
}

sealed partial class HelloService(ILogger<HelloService> logger,
    IOptions<HelloOptions> options) : IHostedService
{
    Task IHostedService.StartAsync(CancellationToken cancellationToken)
    {
        LogHello(options.Value.Name);
        return Task.CompletedTask;
    }

    Task IHostedService.StopAsync(CancellationToken cancellationToken)
    {
        LogBye(options.Value.Name);
        return Task.CompletedTask;
    }

    [LoggerMessage(Level = LogLevel.Information, Message = "Hello, {name}")]
    private partial void LogHello(string name);

    [LoggerMessage(Level = LogLevel.Information, Message = "Bye, {name}...")]
    private partial void LogBye(string name);
}
