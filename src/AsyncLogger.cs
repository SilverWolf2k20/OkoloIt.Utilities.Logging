﻿using OkoloIt.Utilities.Logging.Configuration;

namespace OkoloIt.Utilities.Logging
{
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
        internal AsyncLogger(LoggerConfigurations configurations)
            : base(configurations)
        {
        }

        #endregion Internal Constructors

        #region Public Methods

        /// <summary>
        /// Асинхронно выводит сообщение отладки.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        public async void Debug(string message)
        {
#if DEBUG
            await WriteAsync(LogLevel.Debug, message);
#endif
        }

        /// <summary>
        /// Асинхронно выводит сообщение ошибки.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        public async void Error(string message)
            => await WriteAsync(LogLevel.Error, message);

        /// <summary>
        /// Асинхронно выводит сообщение критической ошибки.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        public async void Fatal(string message)
            => await WriteAsync(LogLevel.Fatal, message);

        /// <summary>
        /// Асинхронно выводит информационное сообщение.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        public async void Info(string message)
            => await WriteAsync(LogLevel.Info, message);

        /// <summary>
        /// Асинхронно выводит сообщение.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        public async void Trace(string message)
            => await WriteAsync(LogLevel.Trace, message);

        /// <summary>
        /// Асинхронно выводит сообщение о не штатном поведении.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        public async void Warn(string message)
            => await WriteAsync(LogLevel.Warn, message);

        #endregion Public Methods

        #region Private Methods

        private async Task WriteAsync(LogLevel level, string message)
            => await Task.Run(() => Write(level, message));

        #endregion Private Methods
    }
}