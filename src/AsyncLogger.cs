using OkoloIt.Utilities.Logging.Configuration;

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
        /// <param name="action">Метод для вывода сообщения.</param>
        internal AsyncLogger(LoggerConfiguration configurations, Action<string>? action)
            : base(configurations, action)
        {
        }

        #endregion Internal Constructors

        #region Public Methods

        /// <summary>
        /// Асинхронно выводит сообщение отладки.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        public async void Debug(string message)
            => await WriteDebugMessageAsync(message);

        /// <summary>
        /// Асинхронно выводит сообщение ошибки.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        public async void Error(string message)
            => await WriteMessageAsync(LogLevel.Error, message);

        /// <summary>
        /// Асинхронно выводит сообщение критической ошибки.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        public async void Fatal(string message)
            => await WriteMessageAsync(LogLevel.Fatal, message);

        /// <summary>
        /// Асинхронно выводит информационное сообщение.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        public async void Info(string message)
            => await WriteMessageAsync(LogLevel.Info, message);

        /// <summary>
        /// Асинхронно выводит сообщение.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        public async void Trace(string message)
            => await WriteMessageAsync(LogLevel.Trace, message);

        /// <summary>
        /// Асинхронно выводит сообщение о не штатном поведении.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        public async void Warn(string message)
            => await WriteMessageAsync(LogLevel.Warn, message);

        #endregion Public Methods

        #region Private Methods

        private async Task WriteMessageAsync(LogLevel level, string message)
            => await Task.Run(() => WriteMessage(level, message));

        private async Task WriteDebugMessageAsync(string message)
            => await Task.Run(() => WriteDebugMessage(message));

        #endregion Private Methods
    }
}