namespace OkoloIt.Utilities.Logging;

/// <summary>
/// Менеджер логера.
/// </summary>
public sealed class LoggerManager
{
    #region Public Properties

    /// <summary>
    /// Текущий логгер.
    /// </summary>
    public static ILogger? CurrentLogger { get; internal set; }

    #endregion Public Properties
}