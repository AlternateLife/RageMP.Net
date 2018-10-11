using System.Numerics;

namespace RageMP.Net.Interfaces
{
    public interface IVehiclePool : IPool<IVehicle>
    {
        IVehicle New(uint model, Vector3 position, float heading, string numberPlate, uint alpha, bool locked, bool engine, uint dimension);
    }
}
