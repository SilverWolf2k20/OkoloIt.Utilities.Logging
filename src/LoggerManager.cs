namespace OkoloIt.Utilities.Logging;

/// <summary>
/// Менеджер логера.
/// </summary>
public sealed class LoggerManager
{
    #region Private Fields

    private static ILogger? _logger;

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// Возвращает логер, если он существует.
    /// </summary>
    /// <returns>Логер.</returns>
    /// <exception cref="NullReferenceException"> если логер не был создан.</exception>
    public static ILogger GetLogger()
    {
        if (_logger is null)
            throw new NullReferenceException("Не существует класса ILogger!");

        return _logger;
    }

    #endregion Public Methods

    #region Internal Methods

    /// <summary>
    /// Устанавливает логер.
    /// </summary>
    /// <param name="logger">Логер.</param>
    internal static void SetLogger(ILogger logger)
        => _logger = logger;

    #endregion Internal Methods
}