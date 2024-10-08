using OkoloIt.Utilities.Logging.Configuration;

namespace OkoloIt.Utilities.Logging;

/// <summary>
/// Менеджер логера.
/// </summary>
public sealed class LoggerManager
{
    #region Private Fields

    private static ILogger? _logger;

    #endregion Private Fields

    #region Public Properties

    /// <summary>
    /// Текущий логгер.
    /// </summary>
    public static ILogger CurrentLogger {
        get => _logger ?? new Logger(new LoggerConfiguration(), null);
        set => _logger = value;
    }

    /// <summary>
    /// Текущая настройка логгера.
    /// </summary>
    public static LoggerConfiguration? CurrentConfiguration { get; internal set; }

    #endregion Public Properties
}