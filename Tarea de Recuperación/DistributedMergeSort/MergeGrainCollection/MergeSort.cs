using System.Threading.Tasks;
using Orleans;
using MergeInterface;
using System.Collections.Generic;
using System;
using System.IO;

namespace MergeGrainCollection
{
    /// <summary>
    /// Grain implementation class Grain1.
    /// </summary>
    [Serializable]
    public class MergeSort : Grain, IMergeSort
    {
        public Task<string> PruebaOrleans() {
            return Task.FromResult("Hola hola esto es una prueba brother, YA SABES USAR ORLEANS... bueno maso.");
        }

        public Task<List<string>> Merge(List<string> array, int p, int q, int r) {
            int n1 = q - p + 1;
            int n2 = r - q;
            List<string> L = new List<string>();
            List<string> R = new List<string>();
            for (int uno = 1; uno <= n1; uno++) {
                L.Add(array[p + uno - 2]);
            }
            for (int dos = 1; dos <= n2; dos++) {
                R.Add(array[q + dos -1]);
            }
            string sentinel = "zzzzzzzzzzzzzzzzzzzz";
            L.Add(sentinel);
            R.Add(sentinel);
            int i = 0;
            int j = 0;
            for (int k = p; k <= r; k++) {
                int comparacion = L[i].CompareTo(R[j]);

                if (comparacion <= 0) {
                    array[k - 1] = L[i];
                    i++;
                }else
                {
                    array[k - 1] = R[j];
                    j++;
                }
            }

            return Task.FromResult(array);

        }
    }
}
