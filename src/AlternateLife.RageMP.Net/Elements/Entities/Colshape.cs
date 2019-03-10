using System;
using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Entities
{
    internal class Colshape : Entity, IColshape
    {
        internal Colshape(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin, EntityType.Colshape)
        {
        }

        public ColshapeType GetShapeType()
        {
            CheckExistence();

            return (ColshapeType) Rage.Colshape.Colshape_GetShapeType(NativePointer);
        }

        public Task<ColshapeType> GetShapeTypeAsync()
        {
            return _plugin.Schedule(GetShapeType);
        }

        public bool IsPointWhithin(Vector3 position)
        {
            CheckExistence();

            return Rage.Colshape.Colshape_IsPointWithin(NativePointer, position);
        }

        public Task<bool> IsPointWhithinAsync(Vector3 position)
        {
            return _plugin.Schedule(() => IsPointWhithin(position));
        }
    }
}
