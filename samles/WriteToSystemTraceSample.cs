﻿using OkoloIt.Utilities.Logging.Configuration;

namespace OkoloIt.Utilities.Logging.Samples;

internal class WriteToSystemTraceSample : WriterSample
{
    protected internal override void InitializationLogger()
    {
        ILogger logger = new LoggerBuilder()
            .SetMinimalLevel(LogLevel.Trace)
            .SetWriteFormat()
            .WriteToSystemTrace()
            .UseAsync()
            .Build();

        logger.Info("Создан логер!");
    }
}