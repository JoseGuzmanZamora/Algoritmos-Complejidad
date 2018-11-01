using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;

namespace MergeInterface
{
    /// <summary>
    /// Grain interface IGrain1
    /// </summary>
    public interface IMergeSort : IGrainWithGuidKey
    {
        Task<string> PruebaOrleans();

        Task<List<string>> Merge(List<string> array, int p, int q, int r);



    }
}
