using RageMP.Net.Interfaces;

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
            throw new System.NotImplementedException();
        }
    }
}
