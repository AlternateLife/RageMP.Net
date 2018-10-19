using System.Numerics;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface IVehiclePool : IPool<IVehicle>
    {
        IVehicle New(VehicleHash model, Vector3 position, float heading = 0, string numberPlate = "", uint alpha = 255, bool locked = false, bool engine = false,
            uint dimension = MP.GlobalDimension);
    }
}
