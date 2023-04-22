namespace OkoloIt.Utilities.Logging.Samples;

/// <summary>
/// Интерфейс примера записывателя.
/// </summary>
internal abstract class WriterSample
{
    /// <summary>
    /// Иницифлизирует логер.
    /// </summary>
    protected internal abstract void InitializationLogger();

    /// <summary>
    /// Выполняет работу.
    /// </summary>
    protected internal void Work()
    {
        ILogger? logger = LoggerManager.CurrentLogger;

        logger?.Trace("Сообщения уровня Trace.");
        logger?.Debug("Сообщения уровня Debug.");
        logger?.Info("Сообщения уровня Info.");
        logger?.Warn("Сообщения уровня Warn.");
        logger?.Error("Сообщения уровня Error.");
        logger?.Fatal("Сообщения уровня Fatal.");
    }
}