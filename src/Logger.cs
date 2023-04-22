using System.Runtime.CompilerServices;

using OkoloIt.Utilities.Logging.Configuration;
using OkoloIt.Utilities.Logging.Data;

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
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0
    )
        => WriteMessageSync(LogLevel.Debug, message, member, file, line);

    /// <summary>
    /// Выводит сообщение ошибки.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public void Error(
        string message,
        [CallerMemberName] string member = "",
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0
    )
        => WriteMessageSync(LogLevel.Error, message, member, file, line);

    /// <summary>
    /// Выводит сообщение критической ошибки.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public void Fatal(
        string message,
        [CallerMemberName] string member = "",
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0
    )
        => WriteMessageSync(LogLevel.Fatal, message, member, file, line);

    /// <summary>
    /// Выводит информационное сообщение.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public void Info(
        string message,
        [CallerMemberName] string member = "",
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0
    )
        => WriteMessageSync(LogLevel.Info, message, member, file, line);

    /// <summary>
    /// Выводит сообщение.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public void Trace(
        string message,
        [CallerMemberName] string member = "",
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0
    )
        => WriteMessageSync(LogLevel.Trace, message, member, file, line);

    /// <summary>
    /// Выводит сообщение о не штатном поведении.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public void Warn(
        string message,
        [CallerMemberName] string member = "",
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0
    )
        => WriteMessageSync(LogLevel.Warn, message, member, file, line);

    #endregion Public Methods

    #region Private Methods

    private void WriteMessageSync(
        LogLevel level, 
        string message,
        string member, 
        string file, 
        int line
    )
    {
        LogMessage log = new(level, message) {
            CallerMember = member,
            CallerFile = file,
            CallerLine = line
        };

        WriteMessage(log);
    }

    #endregion 
}