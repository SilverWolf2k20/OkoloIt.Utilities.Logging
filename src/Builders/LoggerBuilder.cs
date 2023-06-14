using OkoloIt.Utilities.Logging.Configuration;

namespace OkoloIt.Utilities.Logging;

/// <summary>
/// Строитель логера.
/// </summary>
public class LoggerBuilder : ILoggerBuilder
{
    #region Private Fields

    private LoggerConfiguration _configuration = new();
    private Action<string>? _action;

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
            logger = new AsyncLogger(_configuration, _action);
        else
            logger = new Logger(_configuration, _action);

        LoggerManager.CurrentLogger = logger;

        return logger;
    }

    /// <summary>
    /// Устанавливает конфигурацию для логера.
    /// </summary>
    /// <param name="configuration">Конфигурация логера.</param>
    /// <returns>
    /// Экземпляр строителя, наследуемого от <see cref="ILoggerBuilder"/>.
    /// </returns>
    public ILoggerBuilder SetConfiguration(LoggerConfiguration configuration)
    {
        _configuration = configuration;
        return this;
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
        _configuration.MinimalLevel = level;
        return this;
    }

    /// <summary>
    /// Устанавливает формат вывода сообщений.
    /// </summary>
    /// <param name="format">Формат вывода сообщения.</param>
    /// <returns>
    /// Экземпляр строителя, наследуемого от <see cref="ILoggerBuilder"/>.
    /// </returns>
    public ILoggerBuilder SetWriteFormat(string format)
    {
        _configuration.Format = format;
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
        _configuration.Output = OutputType.Console;
        return this;
    }

    /// <summary>
    /// Устанавливает вывод сообщений в метод.
    /// </summary>
    /// <param name="action">Метод записи сообщений.</param>
    /// <returns>
    /// Экземпляр строителя, наследуемого от <see cref="ILoggerBuilder"/>.
    /// </returns>
    public ILoggerBuilder WriteToCustom(Action<string> action)
    {
        _configuration.Output = OutputType.Custom;
        _action = action;
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
        _configuration.Output = OutputType.File;

        if (string.IsNullOrEmpty(fileName) == false)
            _configuration.FileName  = fileName;

        return this;
    }

    /// <summary>
    /// Устанавливает вывод сообщений в системную консоль.
    /// </summary>
    /// <returns>
    /// Экземпляр строителя, наследуемого от <see cref="ILoggerBuilder"/>.
    /// </returns>
    public ILoggerBuilder WriteToSystemTrace()
    {
        _configuration.Output = OutputType.System;
        return this;
    }

    #endregion Public Methods
}