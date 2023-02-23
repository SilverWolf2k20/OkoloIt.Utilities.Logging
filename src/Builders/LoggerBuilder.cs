using OkoloIt.Utilities.Logging.Configuration;

namespace OkoloIt.Utilities.Logging
{
    /// <summary>
    /// Строитель логера.
    /// </summary>
    public class LoggerBuilder : ILoggerBuilder
    {
        #region Private Fields

        private readonly LoggerConfigurations _configuration = new();

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Строит логер, наследуемый от <see cref="ILogger"/>.
        /// </summary>
        /// <returns>Созданный логер.</returns>
        public ILogger Build()
        {
            ILogger logger;

            if (_configuration.UseAsyncWrite)
                logger = new AsyncLogger(_configuration);
            else
                logger = new Logger(_configuration);

            LoggerManager.SetLogger(logger);

            return logger;
        }

        /// <summary>
        /// Устанавливает минимальный уровень логирования.
        /// </summary>
        /// <param name="level">Минимальный уровень логирования.</param>
        /// <returns>
        /// Экземпляр строителя, наследуемого от <see cref="ILoggerBuilder"/>.
        /// </returns>
        public ILoggerBuilder SetMinimalLevel(LogLevel level)
        {
            return this;
        }


        /// <summary>
        /// Устанавливает формат вывода сообщений.
        /// </summary>
        /// <returns>
        /// Экземпляр строителя, наследуемого от <see cref="ILoggerBuilder"/>.
        /// </returns>
        public ILoggerBuilder SetWriteFormat()
        {
            return this;
        }

        /// <summary>
        /// Настраивает логер на асинхронную работу.
        /// </summary>
        /// <returns>
        /// Экземпляр строителя, наследуемого от <see cref="ILoggerBuilder"/>.
        /// </returns>
        public ILoggerBuilder UseAsync()
        {
            _configuration.UseAsyncWrite = true;
            return this;
        }

        /// <summary>
        /// Устанавливает вывод сообщений в консоль.
        /// </summary>
        /// <returns>
        /// Экземпляр строителя, наследуемого от <see cref="ILoggerBuilder"/>.
        /// </returns>
        public ILoggerBuilder WriteToConsole()
        {
            _configuration.InConsole = true;
            return this;
        }

        /// <summary>
        /// Устанавливает вывод сообщений в файл.
        /// </summary>
        /// <returns>
        /// Экземпляр строителя, наследуемого от <see cref="ILoggerBuilder"/>.
        /// </returns>
        public ILoggerBuilder WriteToFile(string fileName)
        {
            _configuration.FileName  = fileName;
            _configuration.InConsole = false;
            return this;
        }

        #endregion Public Methods
    }
}