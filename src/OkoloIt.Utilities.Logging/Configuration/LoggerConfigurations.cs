namespace OkoloIt.Utilities.Logging.Configuration;

/// <summary>
/// Конфигурация логера.
/// </summary>
public record class LoggerConfiguration
{
    /// <summary>
    /// Перезаписывать файл при инициализации логера.
    /// </summary>
    public bool CanRewriteFile { get; set; } = default;

    /// <summary>
    /// Путь вывода.
    /// </summary>
    public OutputTypes Output { get; set; } = default;

    /// <summary>
    /// Использовать асинхронную запись.
    /// </summary>
    public bool UseAsyncWrite { get; set; } = false;

    /// <summary>
    /// Имя файла для записи.
    /// </summary>
    public string FileName { get; set; } = "logs.log";

    /// <summary>
    /// Формат вывода лога.
    /// </summary>
    public string Format { get; set; } = "yyyy:MM:dd HH:mm:ss:ffff; {0} {1} ({2}): ";

    /// <summary>
    /// Минимальный уровень логов.
    /// </summary>
    public LogLevel MinimalLevel { get; set; } = LogLevel.Trace;
}