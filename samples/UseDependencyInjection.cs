using Microsoft.Extensions.Logging;

using OkoloIt.Utilities.Logging.Extensions.Logging;

namespace OkoloIt.Utilities.Logging.Samples;

internal class UseDependencyInjection : WriterSample
{
    private Microsoft.Extensions.Logging.ILogger? _logger;

    protected internal override void InitializationLogger()
    {
        ILogger logger = new LoggerBuilder()
            .SetMinimalLevel(Configuration.LogLevel.Trace)
            .SetWriteFormat(" {0:yyyy:MM:dd HH:mm:ss:ffff} {1} ({2}): ")
            .WriteToSystemTrace()
            .WriteToConsole()
            .Build();

        using var loggerFactory = LoggerFactory.Create(builder => builder.AddLogger(logger));

        _logger = loggerFactory.CreateLogger<Program>();
        _logger.LogInformation("Создан логер!");
    }

    protected internal override void Work()
    {
        _logger?.LogTrace($"Сообщение уровня {LogLevel.Trace}.");
        _logger?.LogDebug("Сообщение уровня {0}.", LogLevel.Debug);
        _logger?.LogInformation(@$"Сообщение уровня Info.");
        _logger?.LogWarning("Сообщение {0} {1}.", "уровня", LogLevel.Warning);
        _logger?.LogError($"Сообщение {"уровня"} {LogLevel.Error}.");
        _logger?.LogCritical(@"Сообщение уровня Fatal.");
    }
}