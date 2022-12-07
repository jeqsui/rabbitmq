namespace Clients.Services;

/// <summary>
/// Structure for testing pass-by-value calls.
/// </summary>
public interface IService
{
    /// <returns>left + right</returns>
    double AddLiteralHeatUseVar(double value);

}