namespace Voltaria;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class BadRequestError(object body) : VoltariaApiApiException("BadRequestError", 400, body);
