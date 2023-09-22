﻿using OkoloIt.Utilities.Logging.Configuration;

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

    /// <inheritdoc/>
    public ILoggerBuilder CanRewriteFile()
    {
        _configuration.CanRewriteFile = true;

        return this;
    }

    /// <inheritdoc/>
    public ILogger Build()
    {
        ILogger logger;

        if (_configuration.UseAsyncWrite)
            logger = new AsyncLogger(_configuration, _action);
        else
            logger = new Logger(_configuration, _action);

        LoggerManager.CurrentLogger = logger;

        if (_configuration.Output == OutputType.File)
            RewriteFile();

        return logger;
    }

    /// <inheritdoc/>
    public ILoggerBuilder SetConfiguration(LoggerConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        _configuration = configuration;
        return this;
    }

    /// <inheritdoc/>
    public ILoggerBuilder SetMinimalLevel(LogLevel level)
    {
        ArgumentNullException.ThrowIfNull(level);

        _configuration.MinimalLevel = level;
        return this;
    }

    /// <inheritdoc/>
    public ILoggerBuilder SetWriteFormat(string format)
    {
        ArgumentNullException.ThrowIfNull(format);

        _configuration.Format = format;
        return this;
    }

    /// <inheritdoc/>
    public ILoggerBuilder UseAsync()
    {
        _configuration.UseAsyncWrite = true;
        return this;
    }

    /// <inheritdoc/>
    public ILoggerBuilder WriteToConsole()
    {
        _configuration.Output = OutputType.Console;
        return this;
    }

    /// <inheritdoc/>
    public ILoggerBuilder WriteToCustom(Action<string> action)
    {
        ArgumentNullException.ThrowIfNull(action);

        _configuration.Output = OutputType.Custom;
        _action = action;
        return this;
    }

    /// <inheritdoc/>
    public ILoggerBuilder WriteToFile(string fileName)
    {
        ArgumentNullException.ThrowIfNull(fileName);

        _configuration.Output = OutputType.File;

        if (string.IsNullOrEmpty(fileName) == false)
            _configuration.FileName  = fileName;

        return this;
    }

    /// <inheritdoc/>
    public ILoggerBuilder WriteToSystemTrace()
    {
        _configuration.Output = OutputType.System;
        return this;
    }

    #endregion Public Methods

    #region Private Methods

    private void RewriteFile()
    {
        if (_configuration.CanRewriteFile == false)
            return;

        using var _ = File.Create(_configuration.FileName);
    }

    #endregion Private Methods
}