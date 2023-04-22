using System.Diagnostics;

using OkoloIt.Utilities.Logging.Configuration;
using OkoloIt.Utilities.Logging.Data;

namespace OkoloIt.Utilities.Logging;

/// <summary>
/// Базовый класс логера.
/// </summary>
public class LoggerBase
{
    #region Protected Fields

    /// <summary>
    /// Конфигурация логера.
    /// </summary>
    protected LoggerConfiguration _configurations;
    protected Action<string>? _action;

    #endregion Protected Fields

    #region Private Fields

    private static object _locker = new();

    #endregion Private Fields

    #region Protected Constructors

    /// <summary>
    /// Создает экземпляр базового класса логера.
    /// </summary>
    /// <param name="configurations">Конфигурация логера.</param>
    /// <param name="action">Метод для вывода сообщения.</param>
    internal LoggerBase(LoggerConfiguration configurations, Action<string>? action)
    {
        _configurations = configurations;
        _action = action;
    }

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
    /// Записывает сообщение.
    /// </summary>
    /// <param name="level">Уровень лога.</param>
    /// <param name="message">Сообщение лога.</param>
    protected virtual void WriteMessage(LogMessage message)
    {
        lock (_locker) {
            if (IsVisibleMessage(message.Level) == false)
                return;

            switch (_configurations.Output) {
                case OutputType.Console:
                    WriteInConsole(message);
                    return;
                case OutputType.File:
                    WriteInFile(message);
                    return;
                case OutputType.System:
                    WriteInSystemTrace(message);
                    return;
                case OutputType.Custom:
                    WriteInCustomMethod(message);
                    return;
                default:
                    throw new NotImplementedException("Нет доступного метода для вывода сообщения.");
            }
        }
    }

    /// <summary>
    /// Записывает сообщение в консоль.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    protected virtual void WriteInConsole(LogMessage message)
    {
        Console.ForegroundColor = LevelToColorConverter(message.Level);
        Console.Write($"[{message.GetLevel()}]");
        Console.ResetColor();
        Console.WriteLine($": {message.GetLog()}");
    }

    /// <summary>
    /// Записывает сообщение в пользовательский метод.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    protected virtual void WriteInCustomMethod(LogMessage message)
        => _action?.Invoke($"[{message.GetLevel()}] {message.GetLog()}");

    /// <summary>
    /// Записывает сообщение в файл.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    protected virtual void WriteInFile(LogMessage message)
    {
        using var writer = new StreamWriter(_configurations.FileName, true);
        writer.WriteLineAsync($"[{message.GetLevel()}] {message.GetLog()}");
    }

    /// <summary>
    /// Записывает сообщение в системную консоль.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    protected virtual void WriteInSystemTrace(LogMessage message)
        => Trace.WriteLine($"[{message.GetLevel()}] {message.GetLog()}");

    #endregion Protected Methods
}