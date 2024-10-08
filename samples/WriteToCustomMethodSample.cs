using OkoloIt.Utilities.Logging.Configuration;

namespace OkoloIt.Utilities.Logging.Samples;

internal class WriteToCustomMethodSample : WriterSample
{
    protected internal override void InitializationLogger()
    {
        ILogger logger = new LoggerBuilder()
            .SetMinimalLevel(LogLevel.Trace)
            .SetWriteFormat(" {0:yyyy:MM:dd HH:mm:ss} ({2}): ")
            .WriteToCustom((level, msg) => Console.WriteLine($"Срач-сообщение: [level]: {msg}"))
            .UseAsync()
            .Build();

        logger.Info("Создан логер!");
    }
}