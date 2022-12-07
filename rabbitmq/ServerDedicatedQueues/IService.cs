namespace Servers;
/// <summary>
/// Service contract.
/// </summary>	
public interface IService
{
    /// call  the methods  that are being called from client 
    double AddLiteralHeatUseVar(double value);
    double AddLiteralFoodUseVar(double value);
}