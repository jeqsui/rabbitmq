using System;
using System.Threading;
using NLog;
using Commons.Utils;

namespace Servers
{
    class Server
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
            //configure logging
            LoggingUtil.ConfigureNLog();

            while (true)
            {
                try
                {
                    //start service
                    var service = new Service();

                    //
                    log.Info("Server has been started.");

                    //hang main thread						
                    while (true)
                    {
                        Thread.Sleep(1000);
                    }
                }
                catch (Exception e)
                {
                    //log exception
                    log.Error(e, "Unhandled exception caught. Server will now restart.");

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
            var self = new Server();
            self.Run();
        }
    }
}
