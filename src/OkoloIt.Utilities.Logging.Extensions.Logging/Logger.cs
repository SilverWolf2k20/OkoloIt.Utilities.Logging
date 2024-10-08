using Microsoft.Extensions.Logging;

namespace OkoloIt.Utilities.Logging.Extensions.Logging;

/// <summary>
/// Логгер.
/// </summary>
/// <param name="provider">Провайдер логгера.</param>
/// <param name="logger">Объект текущего логгера.</param>
/// <param name="name">Наименование контекста.</param>
internal class Logger(
    LoggerProvider provider,
    ILogger? logger,
    string name) 
    : Microsoft.Extensions.Logging.ILogger
{
    #region Private Fields

    private readonly ILogger _logger = logger ?? LoggerManager.CurrentLogger;
    private readonly string _name = name;
    private readonly LoggerProvider _provider = provider;

    #endregion Private Fields

    #region Public Methods

    /// <inheritdoc/>
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return _provider;
    }

    /// <inheritdoc/>
    public bool IsEnabled(LogLevel logLevel)
    {
        return _logger.IsEnabled(logLevel);
    }

    /// <inheritdoc/>
    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception? exception,
        Func<TState, Exception?, string> formatter)
    {
        if (_logger.IsEnabled(logLevel) == false)
            return;

        _logger.Log(logLevel, Format(state), _name);
    }

    #endregion Public Methods

    #region Private Methods

    private string Format<TState>(TState state)
    {
        if ((object?)state is not IEnumerable<KeyValuePair<string, object>> enumerable)
            return "Logger state in the wrong format!";

        List<object> arguments = [];
        foreach (KeyValuePair<string, object> item in enumerable) {
            if (item.Key == "{OriginalFormat}" && item.Value is string message)
                return string.Format(message, arguments.ToArray());

            arguments.Add(item.Value);
        }

        return string.Empty;
    }

    #endregion Private Methods
}
