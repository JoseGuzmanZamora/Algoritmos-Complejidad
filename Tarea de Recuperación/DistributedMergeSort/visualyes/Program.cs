using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace visualyes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            // First, configure and start a local silo
            var siloConfig = ClusterConfiguration.LocalhostPrimarySilo();
            var silo = new SiloHost("TestSilo", siloConfig);
            silo.InitializeOrleansSilo();
            silo.StartOrleansSilo();

            Console.WriteLine("Silo started.");

            // Then configure and connect a client.
            var clientConfig = ClientConfiguration.LocalhostSilo();
            var client = new ClientBuilder().UseConfiguration(clientConfig).Build();
            client.Connect().Wait();

            Console.WriteLine("Client connected.");

            //
            var saludo = client.GetGrain<MergeInterface.IMergeSort>(Guid.NewGuid());
            var resultado = ReadFileYeah(@"C: \Users\Chino Guzman\source\repos\DistributedMergeSort\oraciones.txt").ToList();
            /*var valores = decoder(resultado);
            var resultadofinal = MergeSort(saludo, 0, valores, 1, valores.Count);
            foreach(List<int> x in resultadofinal)
            {
                Console.WriteLine(x[0]);
            }
            var valoresfinales = encoder(resultadofinal);
            foreach (char[] x in valoresfinales) {
                foreach (char hola in x) {
                    Console.Write(hola);
                }
                Console.WriteLine("");
            }*/

            var yeah = MergeSort(saludo, resultado, 1, resultado.Count);
            foreach (string x in yeah)
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nPress Enter to terminate...");
            Console.ReadLine();

            // Shut down
            client.Close();
            silo.ShutdownOrleansSilo();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        public static List<string> MergeSort(MergeInterface.IMergeSort grano, List<string> arreglo, int p, int r)
        {
            if (p < r)
            {
                int q = (p + r) / 2;
                arreglo = MergeSort(grano, arreglo, p, q);
                arreglo = MergeSort(grano, arreglo, q + 1, r);
                var temporal = grano.Merge(arreglo, p, q, r);
                temporal.Wait();
                arreglo = temporal.Result;
            }
            return arreglo;

        }

        public static IEnumerable<string> ReadFileYeah(string path)
        {
            IEnumerable<string> info = File.ReadLines(path);
            return info;
        }
    }
}
