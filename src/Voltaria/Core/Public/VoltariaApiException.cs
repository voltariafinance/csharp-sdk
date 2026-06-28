namespace Voltaria;

/// <summary>
/// Base exception class for all exceptions thrown by the SDK.
/// </summary>
public class VoltariaApiException(string message, Exception? innerException = null)
    : Exception(message, innerException);
