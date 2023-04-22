namespace OkoloIt.Utilities.Logging.Configuration;

/// <summary>
/// Тип вывода сообщений.
/// </summary>
public enum OutputType : byte
{
    /// <summary>
    /// Вывод в файл.
    /// </summary>
    File,

    /// <summary>
    /// Вывод в консоль.
    /// </summary>
    Console,

    /// <summary>
    /// Вывод в системную консоль.
    /// </summary>
    System,

    /// <summary>
    /// Пользовательский вывод.
    /// </summary>
    Custom,
}