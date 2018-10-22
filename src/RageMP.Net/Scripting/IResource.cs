using System.Threading.Tasks;

namespace AlternateLife.RageMP.Net.Scripting
{
    public interface IResource
    {
        Task OnStartAsync();
        Task OnStopAsync();
    }
}
