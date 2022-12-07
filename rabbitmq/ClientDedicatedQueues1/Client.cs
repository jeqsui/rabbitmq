namespace Clients;

using NLog;

using Commons.Utils;
using Clients.Services;


/// <summary>
/// Client
/// </summary>
class Client
{
    /// <summary>
    /// Logger for this class.
    /// </summary>
    private Logger log = LogManager.GetCurrentClassLogger();

    /// <summary>
    /// Program body.
    /// </summary>
    private void Run()
    {
        LoggingUtil.ConfigureNLog();

        //main loop
        while (true)
        {
            try
            {
                //connect to server
                var service = new ServiceClient();
                log.Info($"Client ID is '{service.ClientId}'");

                //test service
                var rnd = new Random();

                while (true)
                {
                    //test simple call
                    double value = rnd.Next(0, 100);
                    log.Info(value);
                    service.AddLiteralFoodUseVar(value);

                    Thread.Sleep(2000);
                }
            }
            catch (Exception e)
            {
                //log exceptions
                log.Error(e, "Unhandled exception caught. Restarting.");

                //prevent console spamming
                Thread.Sleep(2000);
            }
        }
    }

    /// <summary>
    /// Program entry point.
    /// </summary>
    /// <param name="args">Command line arguments.</param>
    static void Main(string[] args)
    {
        var self = new Client();
        self.Run();
    }
}
