///Title:   Program.cs
///Author:  Brandon Paul
///Date:    14.6.17
///Purpose: Main program for Bshop SelfHost server program
using System;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace BShop_SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up server configuration
            Uri _baseAddress = new Uri("http://localhost:60064/");
            HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(_baseAddress);
            config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{action}/{id}",
            defaults: new { id = RouteParameter.Optional }
            );
            // Create server
            HttpSelfHostServer server = new HttpSelfHostServer(config);
            // Start listening
            server.OpenAsync().Wait();
            Console.WriteLine("BShop Web-API Self hosted on " + _baseAddress);
            Console.WriteLine("Hit ENTER to exit...");
            Console.ReadLine();
            server.CloseAsync().Wait();
        }
    }
}
