using OkoloIt.Utilities.Logging.Configuration;

namespace OkoloIt.Utilities.Logging.Samples;

internal class WriteToConsoleSample : WriterSample
{
    protected internal override void InitializationLogger()
    {
        ILogger logger = new LoggerBuilder()
            .SetMinimalLevel(LogLevel.Trace)
            .SetWriteFormat(" {0:yyyy:MM:dd HH:mm:ss:ffff} {1} ({2}): ")
            .WriteToSystemTrace()
            .WriteToConsole()
            .UseAsync()
            .Build();

        logger.Info("Создан логер!");
    }
}