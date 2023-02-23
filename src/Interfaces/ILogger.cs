namespace OkoloIt.Utilities.Logging
{
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
        public void Debug(string message);

        /// <summary>
        /// Выводит сообщение ошибки.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        public void Error(string message);

        /// <summary>
        /// Выводит сообщение критической ошибки.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        public void Fatal(string message);

        /// <summary>
        /// Выводит информативное сообщение.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        public void Info(string message);

        /// <summary>
        /// Выводит сообщение.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        public void Trace(string message);

        /// <summary>
        /// Выводит сообщение о не штатном поведении.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        public void Warn(string message);

        #endregion Public Methods
    }
}