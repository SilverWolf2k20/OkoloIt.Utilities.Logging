using OkoloIt.Utilities.Logging.Configuration;

namespace OkoloIt.Utilities.Logging.Samples
{
    internal class WriteToCustomMethodSample : WriterSample
    {
        protected internal override void InitializationLogger()
        {
            ILogger logger = new LoggerBuilder()
                .SetMinimalLevel(LogLevel.Trace)
                .SetWriteFormat()
                .WriteToCustom(msg => Console.WriteLine($"Срач-сообщение: {msg}"))
                .UseAsync()
                .Build();

            logger.Info("Создан логер!");
        }
    }
}