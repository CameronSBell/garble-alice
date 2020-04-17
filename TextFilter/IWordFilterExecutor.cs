using System.Threading.Tasks;

namespace TextFilter
{
    interface IWordFilterExecutor
    {
        Task<bool> isWordFilteredOut();
    }
}
