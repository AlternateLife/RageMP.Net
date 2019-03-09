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

        public async Task<ColshapeType> GetShapeTypeAsync()
        {
            CheckExistence();

            return (ColshapeType) await _plugin
                .Schedule(() => Rage.Colshape.Colshape_GetShapeType(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task<bool> IsPointWhithinAsync(Vector3 position)
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Colshape.Colshape_IsPointWithin(NativePointer, position))
                .ConfigureAwait(false);
        }
    }
}
