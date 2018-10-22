using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface IVehiclePool : IPool<IVehicle>
    {
        /// <summary>
        /// Create a new vehicle.
        /// </summary>
        /// <param name="model">Model of the vehicle</param>
        /// <param name="position">Position of the vehicle</param>
        /// <param name="heading">Heading of the vehicle</param>
        /// <param name="numberPlate">Number plate of the vehicle</param>
        /// <param name="alpha">Alpha of the vehicle</param>
        /// <param name="locked">Locked state of the vehicle</param>
        /// <param name="engine">Engine state of the vehicle</param>
        /// <param name="dimension">Dimension of the vehicle</param>
        /// <returns>New <see cref="IVehicle" /> instance</returns>
        Task<IVehicle> NewAsync(VehicleHash model, Vector3 position, float heading = 0, string numberPlate = "", uint alpha = 255, bool locked = false, bool engine = false,
            uint dimension = MP.GlobalDimension);
    }
}
