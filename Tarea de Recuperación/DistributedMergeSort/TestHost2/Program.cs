using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Orleans;
using Orleans.Runtime.Configuration;
using Orleans.Runtime.Host;

namespace TestHost2
{
    /// <summary>
    /// Orleans test silo host
    /// </summary>
    public class Program
    {
        public static int contador = 0;

        static void Main(string[] args)
        {
            //CONFIGURACIÓN SILO (cluster) LOCAL 
            var siloConfig = ClusterConfiguration.LocalhostPrimarySilo();
            var silo = new SiloHost("TestSilo", siloConfig);
            silo.InitializeOrleansSilo();
            silo.StartOrleansSilo();

            Console.WriteLine("SILO INICIADO EXITÓSAMENTE.");

            //CONFIGURACIÓN CLIENTE
            var clientConfig = ClientConfiguration.LocalhostSilo();
            var client = new ClientBuilder().UseConfiguration(clientConfig).Build();
            client.Connect().Wait();

            Console.WriteLine("CLIENTE CONECTADO EXITÓSAMENTE");

            //LLAMADA DEL GRANO (actor) INICIAL, este no se usa para la distribución per se 
            var principal = client.GetGrain<MergeInterface.IMergeSort>(Guid.NewGuid());
            var resultado = ReadFileYeah(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "oraciones.txt")).ToList();

            //CÁLCULO BÁSICO DE DISTRIBUCIÓN (el primer parámetro es arbitrario)
            var identificadores = distribucion(100, client, resultado);

            //LLAMADA CENTRAL DE MERGE SORT
            var yeah = MergeSort(client, identificadores, identificadores.Count, principal, resultado, 1, resultado.Count);
            WriteFileYeah(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "oraciones.txt"), yeah);

            Console.WriteLine("\nPress Enter to terminate...");
            Console.ReadLine();

            // Shut down
            client.Close();
            silo.ShutdownOrleansSilo();
        }

        public static List<string> MergeSort(Orleans.IClusterClient cliente,  List<Guid> identificadores, int cantidad, MergeInterface.IMergeSort grano, List<string> arreglo, int p, int r)
        {
            var principal = cliente.GetGrain<MergeInterface.IMergeSort>(identificadores[contador]);
            if (contador == (identificadores.Count - 1))
            {
                contador = 0;
            }
            else {
                contador++;
            }

            if (p < r)
            {
                int q = (p + r) / 2;
                arreglo = MergeSort(cliente, identificadores, cantidad, principal, arreglo, p, q);
                arreglo = MergeSort(cliente, identificadores, cantidad, principal, arreglo, q + 1, r);
                var temporal = grano.Merge(arreglo,  p, q, r);
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

        public static void WriteFileYeah(string path, List<string> info) {
            File.WriteAllLines(path, info);
        }

        public static List<Guid> distribucion(int cantidad, IClusterClient cliente, List<string> arreglo) {
            List<Guid> identificadores = new List<Guid>();
            for (int i = 1; i <= cantidad; i++) {
                var nuevograno = cliente.GetGrain<MergeInterface.IMergeSort>(Guid.NewGuid());
                identificadores.Add(nuevograno.GetPrimaryKey());
                
            }
            return identificadores;

        }

        /*
        public static List<List<int>> decoder(List<string> infor) {
            List<List<int>> valores = new List<List<int>>();
            foreach (string algo in infor)
            {
                valores.Add((algo).Select(x => (int)x).ToList());
            }
            return valores;
        }

        public static List<char[]> encoder(List<List<int>> infor) {
            List<char[]> valoresr = new List<char[]>();
            foreach (List<int> otro in infor) {
                valoresr.Add(Encoding.ASCII.GetChars((otro).Select(x => (byte)x).ToArray()));
            }
            return valoresr;
        }*/
    }
}
