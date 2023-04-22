namespace OkoloIt.Utilities.Logging.Configuration;

/// <summary>
/// Уровни логов.
/// </summary>
public enum LogLevel : byte
{
    /// <summary>
    /// Трасировка.
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
    /// Предумпреждение.
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