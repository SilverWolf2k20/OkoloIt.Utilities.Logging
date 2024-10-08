using Microsoft.Extensions.Logging;

namespace OkoloIt.Utilities.Logging.Extensions.Logging;

/// <summary>
/// Расширение строителя логгера.
/// </summary>
public static class LoggerBuilderExtension
{
    #region Public Methods

    /// <summary>
    /// Добавляет логгер.
    /// </summary>
    /// <param name="builder">Строитель логгера.</param>
    /// <param name="logger">Объект текущего логгера.</param>
    /// <returns>Строитель логгера.</returns>
    public static ILoggingBuilder AddLogger(
        this ILoggingBuilder builder,
        ILogger? logger = default)
    {
        ILogger? newLogger = logger;

        builder.AddProvider(new LoggerProvider(newLogger));
        builder.AddFilter<LoggerProvider>(default, LogLevel.Trace);
        return builder;
    }

    #endregion Public Methods
}
