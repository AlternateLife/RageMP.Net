using RageMP.Net.Interfaces;
using RageMP.Net.Native;

namespace RageMP.Net.Entities
{
    public partial class Player
    {
        public IVehicle Vehicle { get; }
        public int Seat { get; }

        public void PutIntoVehicle(IVehicle vehicle, int seat)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveFromVehicle()
        {
            Rage.Player.Player_RemoveFromVehicle(NativePointer);
        }
    }
}
