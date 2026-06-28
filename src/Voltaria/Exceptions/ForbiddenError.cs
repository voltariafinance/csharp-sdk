namespace Voltaria;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ForbiddenError(object body) : VoltariaApiApiException("ForbiddenError", 403, body);
