using Microsoft.Extensions.Logging;

namespace OkoloIt.Utilities.Logging.Extensions.Logging;

/// <summary>
/// Расширение логгера.
/// </summary>
public static class LoggerExtension
{
    #region Public Methods

    /// <summary>
    /// Определяет допустимость записи лога.
    /// </summary>
    /// <param name="logger">Объект логгера.</param>
    /// <param name="logLevel">Уровень лога.</param>
    /// <returns>
    /// Возвращает <see langword="true"/> если данный уровень лога допустим для вывода,
    /// <see langword="false"/> - в противном случае.
    /// </returns>
    public static bool IsEnabled(this ILogger logger, LogLevel logLevel)
    {
        var level = (Configuration.LogLevel)logLevel;

        if (level != Configuration.LogLevel.Off)
            return level >= LoggerManager.CurrentConfiguration?.MinimalLevel;

        return false;
    }

    /// <summary>
    /// Записывает сообщение.
    /// </summary>
    /// <param name="logger">Объект логгера.</param>
    /// <param name="logLevel">Уровень лога.</param>
    /// <param name="message">Сообщение.</param>
    /// <param name="name">Наименование контекста.</param>
    public static void Log(this ILogger logger, LogLevel logLevel, string message, string name)
    {
        switch (logLevel) {
            case LogLevel.Trace:
                logger.Trace(message, string.Empty, name, 0);
                break;
            case LogLevel.Debug:
                logger.Debug(message, string.Empty, name, 0);
                break;
            case LogLevel.Information:
                logger.Info(message, string.Empty, name, 0);
                break;
            case LogLevel.Warning:
                logger.Warn(message, string.Empty, name, 0);
                break;
            case LogLevel.Error:
                logger.Error(message, string.Empty, name, 0);
                break;
            case LogLevel.Critical:
                logger.Fatal(message, string.Empty, name, 0);
                break;
        }
    }

    #endregion Public Methods
}
