namespace OkoloIt.Utilities.Logging.Configuration;

/// <summary>
/// Уровни логов.
/// </summary>
public enum LogLevel : byte
{
    /// <summary>
    /// Трассировка.
    /// </summary>
    Trace,

    /// <summary>
    /// Отладка.
    /// </summary>
    Debug,

    /// <summary>
    /// Информация.
    /// </summary>
    Info,

    /// <summary>
    /// Предупреждение.
    /// </summary>
    Warn,

    /// <summary>
    /// Ошибка.
    /// </summary>
    Error,

    /// <summary>
    /// Критическая ошибка.
    /// </summary>
    Fatal,

    /// <summary>
    /// Отключено.
    /// </summary>
    Off,
}