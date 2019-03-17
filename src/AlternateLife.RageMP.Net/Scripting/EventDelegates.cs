using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.Scripting
{
    public delegate Task AsyncEventHandler<T>(object sender, T eventArgs) where T : System.EventArgs;

    public delegate void PlayerQuitDelegate(IPlayer player, DisconnectReason type, string reason);
    //public delegate void PlayerRemoteEventDelegate(IPlayer player, uint eventNameHash, object[] arguments);

    public delegate Task CommandDelegate(IPlayer player, string[] arguments);
    public delegate bool ParserDelegate<T>(string s, out T val);
}
