
using Microsoft.Extensions.Logging;

namespace OkoloIt.Utilities.Logging.Extensions.Logging;

/// <summary>
/// Провайдер логгера.
/// </summary>
/// <param name="logger">Объект логгера.</param>
public class LoggerProvider(ILogger? logger) : ILoggerProvider
{
    #region Private Fields

    private readonly ILogger? _logger = logger;

    #endregion Private Fields

    #region Public Methods

    /// <inheritdoc/>
    public Microsoft.Extensions.Logging.ILogger CreateLogger(string name)
    {
        return new Logger(this, _logger, name);
    }

    /// <inheritdoc/>
    public void Dispose()
    {
    }

    #endregion Public Methods
}
