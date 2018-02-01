using System;
using Nancy.Hosting.Self;

namespace Kontur.ImageTransformer
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var uri = new Uri("http://localhost:8080");
            
            using (var host = new NancyHost(uri))
            {
                host.Start();

                Console.WriteLine("ImageTransformer Server is running on " + uri);
                Console.WriteLine("Press [Enter] to close the host.");
                Console.ReadLine();
            }
        }
    }
}
