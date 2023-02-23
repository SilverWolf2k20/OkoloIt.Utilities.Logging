using OkoloIt.Utilities.Logging.Configuration;

namespace OkoloIt.Utilities.Logging
{
    /// <summary>
    /// Интерфейс строителя логера.
    /// </summary>
    public interface ILoggerBuilder
    {
        #region Public Methods

        /// <summary>
        /// Строит логер, наследуемый от <see cref="ILogger"/>.
        /// </summary>
        /// <returns>Созданный логер.</returns>
        public ILogger Build();

        /// <summary>
        /// Устанавливает минимальный уровень логирования.
        /// </summary>
        /// <param name="level">Минимальный уровень логирования.</param>
        /// <returns>
        /// Экземпляр строителя, наследуемого от <see cref="ILoggerBuilder"/>.
        /// </returns>
        public ILoggerBuilder SetMinimalLevel(LogLevel level);

        /// <summary>
        /// Устанавливает формат вывода сообщений.
        /// </summary>
        /// <returns>
        /// Экземпляр строителя, наследуемого от <see cref="ILoggerBuilder"/>.
        /// </returns>
        public ILoggerBuilder SetWriteFormat();

        /// <summary>
        /// Настраивает логер на асинхронную работу.
        /// </summary>
        /// <returns>
        /// Экземпляр строителя, наследуемого от <see cref="ILoggerBuilder"/>.
        /// </returns>
        public ILoggerBuilder UseAsync();

        /// <summary>
        /// Устанавливает вывод сообщений в консоль.
        /// </summary>
        /// <returns>
        /// Экземпляр строителя, наследуемого от <see cref="ILoggerBuilder"/>.
        /// </returns>
        public ILoggerBuilder WriteToConsole();

        /// <summary>
        /// Устанавливает вывод сообщений в файл.
        /// </summary>
        /// <returns>
        /// Экземпляр строителя, наследуемого от <see cref="ILoggerBuilder"/>.
        /// </returns>
        public ILoggerBuilder WriteToFile(string fileName);

        #endregion Public Methods
    }
}