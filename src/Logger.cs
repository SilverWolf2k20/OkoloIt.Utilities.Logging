using OkoloIt.Utilities.Logging.Configuration;

namespace OkoloIt.Utilities.Logging
{
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
        internal Logger(LoggerConfigurations configurations, Action<string>? action)
            : base(configurations, action)
        {
        }

        #endregion Internal Constructors

        #region Public Methods

        /// <summary>
        /// Выводит сообщение отладки.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        public void Debug(string message)
        {
#if DEBUG
            Write(LogLevel.Debug, message);
#endif
        }

        /// <summary>
        /// Выводит сообщение ошибки.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        public void Error(string message)
            => Write(LogLevel.Error, message);

        /// <summary>
        /// Выводит сообщение критической ошибки.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        public void Fatal(string message)
            => Write(LogLevel.Fatal, message);

        /// <summary>
        /// Выводит информационное сообщение.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        public void Info(string message)
            => Write(LogLevel.Info, message);

        /// <summary>
        /// Выводит сообщение.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        public void Trace(string message)
            => Write(LogLevel.Trace, message);

        /// <summary>
        /// Выводит сообщение о не штатном поведении.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        public void Warn(string message)
            => Write(LogLevel.Warn, message);

        #endregion Public Methods
    }
}