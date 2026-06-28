namespace Voltaria;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class InternalServerError(object body)
    : VoltariaApiApiException("InternalServerError", 500, body);
