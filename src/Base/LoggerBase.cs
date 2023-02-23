using OkoloIt.Utilities.Logging.Configuration;

namespace OkoloIt.Utilities.Logging
{
    /// <summary>
    /// Базовый класс логера.
    /// </summary>
    public class LoggerBase
    {
        #region Protected Fields

        /// <summary>
        /// Конфигурация логера.
        /// </summary>
        protected LoggerConfigurations _configurations;

        #endregion Protected Fields

        #region Private Fields

        private static object _locker = new();

        #endregion Private Fields

        #region Protected Constructors

        /// <summary>
        /// Создает экземпляр базового класса логера.
        /// </summary>
        /// <param name="configurations">Конфигурация логера.</param>
        internal LoggerBase(LoggerConfigurations configurations)
            => _configurations = configurations;

        #endregion Protected Constructors

        #region Protected Methods

        /// <summary>
        /// Определяет необходимость отображения сообщения.
        /// </summary>
        /// <param name="level">Уровень логирования.</param>
        /// <returns>
        /// Значение <see langword="true"/>, если данное сообщение надо
        /// отобразить, <see langword="true"/> в противном случае.
        /// </returns>
        protected virtual bool IsVisibleMessage(LogLevel level)
        {
            if (level < _configurations.MinimalLevel)
                return false;

            return true;
        }

        /// <summary>
        /// Преобразует уровень логирования в цвет.
        /// </summary>
        /// <param name="level">Преобразуемый уровень логирования.</param>
        /// <returns>Полученный цвет.</returns>
        protected virtual ConsoleColor LevelToColorConverter(LogLevel level)
            => level switch {
                LogLevel.Trace => ConsoleColor.Green,
                LogLevel.Debug => ConsoleColor.Magenta,
                LogLevel.Info => ConsoleColor.Blue,
                LogLevel.Warn => ConsoleColor.Yellow,
                LogLevel.Error => ConsoleColor.Red,
                LogLevel.Fatal => ConsoleColor.DarkRed,
                _ => ConsoleColor.White,
            };

        /// <summary>
        /// Преобразует уровень логирования в строку.
        /// </summary>
        /// <param name="level">Преобразуемый уровень логирования.</param>
        /// <returns>Полученная строка.</returns>
        protected virtual string LevelToStringConverter(LogLevel level)
            => level switch {
                LogLevel.Trace => "TRACE",
                LogLevel.Debug => "DEBUG",
                LogLevel.Info => "INFO",
                LogLevel.Warn => "WARN",
                LogLevel.Error => "ERROR",
                LogLevel.Fatal => "FATAL",
                _ => "NONE:",
            };

        /// <summary>
        /// Записывает сообщение.
        /// </summary>
        /// <param name="level">Уровень лога.</param>
        /// <param name="message">Сообщение лога.</param>
        protected virtual void Write(LogLevel level, string message)
        {
            lock (_locker) {
                if (IsVisibleMessage(level) == false)
                    return;

                string tag = LevelToStringConverter(level);

                if (_configurations.InConsole == true) {
                    WriteInConsole(level, tag, message);
                    return;
                }

                if (_configurations.InConsole == false) {
                    WriteInFile(tag, message);
                    return;
                }
            }
        }

        /// <summary>
        /// Записывает сообщение в консоль.
        /// </summary>
        /// <param name="level">Уровень лога.</param>
        /// <param name="tag">Тэг лога.</param>
        /// <param name="message">Сообщение.</param>
        protected virtual void WriteInConsole(LogLevel level, string tag, string message)
        {
            Thread.Sleep(250);

            Console.ForegroundColor = LevelToColorConverter(level);
            Console.Write($"[{tag}]");
            Console.ResetColor();
            Console.WriteLine($": {message}");
        }

        /// <summary>
        /// Записывает сообщение в файл.
        /// </summary>
        /// <param name="tag">Тэг лога.</param>
        /// <param name="message">Сообщение.</param>
        protected virtual void WriteInFile(string tag, string message)
        {
        }

        #endregion Protected Methods
    }
}