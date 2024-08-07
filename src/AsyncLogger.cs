﻿using System.Runtime.CompilerServices;

using OkoloIt.Utilities.Logging.Configuration;
using OkoloIt.Utilities.Logging.Data;

namespace OkoloIt.Utilities.Logging;

/// <summary>
/// Асинхронный логер.
/// </summary>
public class AsyncLogger : LoggerBase, ILogger
{
    #region Internal Constructors

    /// <summary>
    /// Создает экземпляр асинхронного логера.
    /// </summary>
    /// <param name="configurations">Конфигурация логера.</param>
    /// <param name="action">Метод для вывода сообщения.</param>
    internal AsyncLogger(LoggerConfiguration configurations, Action<LogLevel, string>? action)
        : base(configurations, action)
    {
    }

    #endregion Internal Constructors

    #region Public Methods

    /// <summary>
    /// Асинхронно выводит сообщение отладки.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public async void Debug(
        string message,
        [CallerMemberName] string member = "",
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0
    )
        => await WriteMessageAsync(LogLevel.Debug, message, member, file, line)
            .ConfigureAwait(false);

    /// <summary>
    /// Асинхронно выводит сообщение ошибки.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public async void Error(
        string message,
        [CallerMemberName] string member = "",
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0
    )
        => await WriteMessageAsync(LogLevel.Error, message, member, file, line)
            .ConfigureAwait(false);

    /// <summary>
    /// Асинхронно выводит сообщение критической ошибки.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public async void Fatal(
        string message,
        [CallerMemberName] string member = "",
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0
    )
        => await WriteMessageAsync(LogLevel.Fatal, message, member, file, line)
            .ConfigureAwait(false);

    /// <summary>
    /// Асинхронно выводит информационное сообщение.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public async void Info(
        string message,
        [CallerMemberName] string member = "",
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0
    )
        => await WriteMessageAsync(LogLevel.Info, message, member, file, line)
            .ConfigureAwait(false);

    /// <summary>
    /// Асинхронно выводит сообщение.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public async void Trace(
        string message,
        [CallerMemberName] string member = "",
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0
    )
        => await WriteMessageAsync(LogLevel.Trace, message, member, file, line)
            .ConfigureAwait(false);

    /// <summary>
    /// Асинхронно выводит сообщение о не штатном поведении.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public async void Warn(
        string message,
        [CallerMemberName] string member = "",
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0
    )
        => await WriteMessageAsync(LogLevel.Warn, message, member, file, line)
            .ConfigureAwait(false);

    #endregion Public Methods

    #region Private Methods

    private async Task WriteMessageAsync(
        LogLevel level,
        string message,
        string member,
        string file,
        int line
    )
    {
        LogMessage log = new(level, message) {
            CallerMember = member,
            CallerFile = Path.GetFileNameWithoutExtension(file) ?? file,
            CallerLine = line
        };

        await Task.Run(() => WriteMessage(log)).ConfigureAwait(false);
    }

    #endregion Private Methods
}