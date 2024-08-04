namespace OkoloIt.Utilities.Logging.Configuration;

/// <summary>
/// Тип вывода сообщений.
/// </summary>
[Flags]
public enum OutputTypes : byte
{
    /// <summary>
    /// Не выводить.
    /// </summary>
    None = 0x00,

    /// <summary>
    /// Вывод в консоль.
    /// </summary>
    Console = 0x01,

    /// <summary>
    /// Вывод в файл.
    /// </summary>
    File = 0x02,

    /// <summary>
    /// Вывод в системную консоль.
    /// </summary>
    System = 0x04,

    /// <summary>
    /// Пользовательский вывод.
    /// </summary>
    Custom = 0x08,
}