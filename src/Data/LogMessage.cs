using System.Text;

using OkoloIt.Utilities.Logging.Configuration;

namespace OkoloIt.Utilities.Logging.Data;

/// <summary>
/// Данные лога.
/// </summary>
public sealed class LogMessage
{
    #region Internal Constructors

    /// <summary>
    /// Сохдает экземпляр данных лога.
    /// </summary>
    /// <param name="level">Уровень лога.</param>
    /// <param name="message">Сообщение.</param>
    internal LogMessage(LogLevel level, string message)
    {
        Level = level;
        Message = message;
        DateTime = DateTime.Now;
    }

    #endregion Internal Constructors

    #region Internal Properties

    /// <summary>
    /// Файл, в котором произошло обращение к логеру.
    /// </summary>
    internal string CallerFile { get; init; } = string.Empty;

    /// <summary>
    /// Строка, в которой произошло обращение к логеру.
    /// </summary>
    internal int CallerLine { get; init; } = 0;

    /// <summary>
    /// Метод, в котором произошло обращение к логеру.
    /// </summary>
    internal string CallerMember { get; init; } = string.Empty;

    /// <summary>
    /// Время создания лога.
    /// </summary>
    internal DateTime DateTime { get; }

    /// <summary>
    /// Уровень лога.
    /// </summary>
    internal LogLevel Level { get; }

    /// <summary>
    /// Сообщение лога.
    /// </summary>
    internal string Message { get; } = string.Empty;

    #endregion Internal Properties

    #region Internal Methods

    /// <summary>
    /// Получает строковое представление уровня лога.
    /// </summary>
    /// <returns>Название уровня лога.</returns>
    internal string GetLevel()
    {
        return $"[{Level}]".ToUpper()
            .PadRight(7, ' ');
    }

    /// <summary>
    /// Возвращает собранное сообщение лога.
    /// </summary>
    /// <returns>Собранное сообщение лога.</returns>
    internal string GetLog(string format)
    {
        try {
            return new StringBuilder().Append(string.Format(
                format,
                DateTime,
                CallerFile,
                CallerLine
            ))
            .Append(Message)
            .ToString();
        }
        catch {
            throw new ArgumentException("Некорректная строка формата!");
        }
    }

    #endregion Internal Methods
}