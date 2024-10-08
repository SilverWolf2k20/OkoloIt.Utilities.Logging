#if NET462_OR_GREATER

namespace OkoloIt.Utilities.Logging;

#pragma warning disable CS1591 // Отсутствует комментарий XML для открытого видимого типа или члена
public static class ArgumentNullException
{
    public static void ThrowIfNull(object? obj)
    {
        if (obj is null)
            throw new System.ArgumentNullException(nameof(obj));
    }
}
#pragma warning restore CS1591 // Отсутствует комментарий XML для открытого видимого типа или члена
#endif
