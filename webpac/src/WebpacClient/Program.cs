using System;

namespace WebpacClient
{
    public class Program
    {
        /// <summary>
        /// Mini example of the usage of Swagger to generate a client Proxy.
        /// SignalR client is not available at the moment.
        /// - To create new proxy, execute CreateProxy.ps1
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //var client = new WebPacClient();
            //client.BaseUri = new Uri("http://localhost:5000");
            //var authReq = new AuthRequest("ReadWriteUsername", "ReadWritePassword");

            //Console.WriteLine("Authentication...");
            //var auth = client.ApiTokenPost(authReq);
            //if ((bool)auth.Authenticated)
            //{
            //    Console.WriteLine("...Authenticated");
            //    var autorization = $"Bearer {auth.Token}";

            //    Console.WriteLine("Call Get on Symbolic Controller...");
            //    foreach (var item in client.ApiSymbolicGet(autorization))
            //        Console.WriteLine($"{item}");
            //    Console.WriteLine("-- finished");
            //}
            //else
            //    Console.WriteLine("Not Authenticated!");

        }
    }
}
