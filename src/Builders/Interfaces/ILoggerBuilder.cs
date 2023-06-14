using OkoloIt.Utilities.Logging.Configuration;

namespace OkoloIt.Utilities.Logging;

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
    /// Устанавливает конфигурацию для логера.
    /// </summary>
    /// <param name="configuration">Конфигурация логера.</param>
    /// <returns>
    /// Экземпляр строителя, наследуемого от <see cref="ILoggerBuilder"/>.
    /// </returns>
    public ILoggerBuilder SetConfiguration(LoggerConfiguration configuration);

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
    /// <param name="format">Формат вывода сообщения.</param>
    /// <returns>
    /// Экземпляр строителя, наследуемого от <see cref="ILoggerBuilder"/>.
    /// </returns>
    public ILoggerBuilder SetWriteFormat(string format);

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
    /// Устанавливает вывод сообщений в метод.
    /// </summary>
    /// <param name="action">Метод записи сообщений.</param>
    /// <returns>
    /// Экземпляр строителя, наследуемого от <see cref="ILoggerBuilder"/>.
    /// </returns>
    public ILoggerBuilder WriteToCustom(Action<string> action);

    /// <summary>
    /// Устанавливает вывод сообщений в файл.
    /// </summary>
    /// <returns>
    /// Экземпляр строителя, наследуемого от <see cref="ILoggerBuilder"/>.
    /// </returns>
    public ILoggerBuilder WriteToFile(string fileName = "");

    /// <summary>
    /// Устанавливает вывод сообщений в системную консоль.
    /// </summary>
    /// <returns>
    /// Экземпляр строителя, наследуемого от <see cref="ILoggerBuilder"/>.
    /// </returns>
    public ILoggerBuilder WriteToSystemTrace();

    #endregion Public Methods
}