using System.Runtime.CompilerServices;

using OkoloIt.Utilities.Logging.Configuration;

namespace OkoloIt.Utilities.Logging;

/// <summary>
/// Синхронный логер.
/// </summary>
public class Logger : LoggerBase, ILogger
{
    #region Internal Constructors

    /// <summary>
    /// Создает экземпляр синхронного логера.
    /// </summary>
    /// <param name="configurations">Конфигурация логера.</param>
    /// <param name="action">Метод для вывода сообщения.</param>
    internal Logger(LoggerConfiguration configurations, Action<string>? action)
        : base(configurations, action)
    {
    }

    #endregion Internal Constructors

    #region Public Methods

    /// <summary>
    /// Выводит сообщение отладки.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public void Debug(
        string message,
        [CallerMemberName] string member = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0
    )
        => WriteMessage(LogLevel.Debug, message);

    /// <summary>
    /// Выводит сообщение ошибки.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public void Error(
        string message,
        [CallerMemberName] string member = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0
    )
        => WriteMessage(LogLevel.Error, message);

    /// <summary>
    /// Выводит сообщение критической ошибки.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public void Fatal(
        string message,
        [CallerMemberName] string member = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0
    )
        => WriteMessage(LogLevel.Fatal, message);

    /// <summary>
    /// Выводит информационное сообщение.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public void Info(
        string message,
        [CallerMemberName] string member = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0
    )
        => WriteMessage(LogLevel.Info, message);

    /// <summary>
    /// Выводит сообщение.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public void Trace(
        string message,
        [CallerMemberName] string member = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0
    )
        => WriteMessage(LogLevel.Trace, message);

    /// <summary>
    /// Выводит сообщение о не штатном поведении.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public void Warn(
        string message,
        [CallerMemberName] string member = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0
    )
        => WriteMessage(LogLevel.Warn, message);

    #endregion Public Methods
}