namespace OkoloIt.Utilities.Logging.Configuration
{
    /// <summary>
    /// Конфигурация логера.
    /// </summary>
    public class LoggerConfiguration
    {
        /// <summary>
        /// Путь вывода.
        /// </summary>
        public OutputType Output { get; set; } = default;

        /// <summary>
        /// Использовать асинхронную запись.
        /// </summary>
        public bool UseAsyncWrite { get; set; } = false;

        /// <summary>
        /// Имя файла для записи.
        /// </summary>
        public string FileName { get; set; } = "logs.log";

        /// <summary>
        /// Минимальный уровень логов.
        /// </summary>
        public LogLevel MinimalLevel { get; set; } = LogLevel.Trace;
    }
}