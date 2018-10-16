using System.Numerics;
using RageMP.Net.Scripting;

namespace RageMP.Net.Interfaces
{
    public interface IVehiclePool : IPool<IVehicle>
    {
        IVehicle New(uint model, Vector3 position, float heading = 0, string numberPlate = "", uint alpha = 255, bool locked = false, bool engine = false,
            uint dimension = MP.GlobalDimension);
    }
}
