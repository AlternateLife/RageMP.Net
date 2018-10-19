using System;
using System.Numerics;
using System.Threading.Tasks;
using RageMP.Net.Data;
using RageMP.Net.Elements.Entities;
using RageMP.Net.Helpers;
using RageMP.Net.Interfaces;
using RageMP.Net.Native;

namespace RageMP.Net.Elements.Pools
{
    internal class TextLabelPool : PoolBase<ITextLabel>, ITextLabelPool
    {
        public TextLabelPool(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin)
        {
        }

        public async Task<ITextLabel> NewAsync(Vector3 position, string text, uint font, ColorRgba color, float drawDistance, bool los, uint dimension)
        {
            var pointer = await _plugin.Schedule(() =>
            {
                using (var converter = new StringConverter())
                {
                    return Rage.TextLabelPool.TextLabelPool_New(_nativePointer, position, converter.StringToPointer(text), font, color, drawDistance, los, dimension);
                }
            }).ConfigureAwait(false);

            return CreateAndSaveEntity(pointer);
        }

        protected override ITextLabel BuildEntity(IntPtr entityPointer)
        {
            return new TextLabel(entityPointer, _plugin);
        }
    }
}
