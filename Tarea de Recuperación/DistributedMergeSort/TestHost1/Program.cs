using System;

using System.Collections.Generic;
using System.IO;
using System.Text;
using Orleans;
using Orleans.Runtime.Configuration;
using Orleans.Runtime.Host;

namespace TestHost1
{
    /// <summary>
    /// Orleans test silo host
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
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
            //var mensaje = saludo.PruebaOrleans();
            //Console.WriteLine(mensaje.Result);
            List<int> prueba = new List<int>();
            prueba.Add(7);
            prueba.Add(79);
            prueba.Add(9);
            prueba.Add(1);
            prueba.Add(32);
            prueba.Add(40);
            prueba.Add(12);


            var otra = MergeSort(client, saludo, prueba, 1, 7);
    
            for (int i = 1; i <= 7; i++)
            {
                Console.WriteLine(otra[i - 1]);
            }

            string text = File.ReadAllText(@"C: \Users\Chino Guzman\source\repos\DistributedMergeSort\oraciones.txt");
            Console.WriteLine(text);
            byte[] valores = Encoding.ASCII.GetBytes(text);
            List<int> valoresconvert = new List<int>();
            foreach (byte element in valores) {
                valoresconvert.Add((int)element);
            }
            var final = MergeSort(client, saludo, valoresconvert, 1, valoresconvert.Count);
            foreach (int element in final) {
                Console.WriteLine(element);
            }
            
            Console.WriteLine("\nPress Enter to terminate...");
            Console.ReadLine();

            // Shut down
            client.Close();
            silo.ShutdownOrleansSilo();
        }

        public static List<int> MergeSort(Orleans.IClusterClient cliente, MergeInterface.IMergeSort grano, List<int> arreglo, int p, int r)
        {
            var maltrato = cliente.GetGrain<MergeInterface.IMergeSort>(Guid.NewGuid());
            if (p < r)
            {
                int q = (p + r) / 2;
                arreglo = MergeSort(cliente, maltrato, arreglo, p, q);
                arreglo = MergeSort(cliente, maltrato, arreglo, q + 1, r);
                var temporal = maltrato.Merge(arreglo, p, q, r);
                temporal.Wait();
                arreglo = temporal.Result;
            }
            return arreglo;

        }
    }
}
