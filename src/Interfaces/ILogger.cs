using System.Runtime.CompilerServices;

namespace OkoloIt.Utilities.Logging;

/// <summary>
/// Интерфейс логера.
/// </summary>
public interface ILogger
{
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
    );

    /// <summary>
    /// Выводит сообщение ошибки.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public void Error(
        string message,
        [CallerMemberName] string member = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0
    );

    /// <summary>
    /// Выводит сообщение критической ошибки.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public void Fatal(
        string message,
        [CallerMemberName] string member = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0
    );

    /// <summary>
    /// Выводит информационное сообщение.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public void Info(
        string message,
        [CallerMemberName] string member = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0
    );

    /// <summary>
    /// Выводит сообщение.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public void Trace(
        string message,
        [CallerMemberName] string member = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0
    );

    /// <summary>
    /// Выводит сообщение о не штатном поведении.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public void Warn(
        string message,
        [CallerMemberName] string member = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0
    );

    #endregion Public Methods
}