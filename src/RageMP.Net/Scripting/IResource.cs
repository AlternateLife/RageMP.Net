using System.Threading.Tasks;

namespace RageMP.Net.Scripting
{
    public interface IResource
    {
        Task OnStartAsync();
        Task OnStopAsync();
    }
}
