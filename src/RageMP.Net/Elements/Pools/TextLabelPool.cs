using System;
using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Elements.Entities;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Pools
{
    internal class TextLabelPool : PoolBase<ITextLabel>, ITextLabelPool
    {
        public TextLabelPool(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin)
        {
        }

        public async Task<ITextLabel> NewAsync(Vector3 position, string text, uint font, ColorRgba color, float drawDistance, bool los, uint dimension)
        {
            using (var converter = new StringConverter())
            {
                var textPointer = converter.StringToPointer(text);

                var pointer = await _plugin
                    .Schedule(() => Rage.TextLabelPool.TextLabelPool_New(_nativePointer, position, textPointer, font, color, drawDistance, los, dimension))
                    .ConfigureAwait(false);

                return CreateAndSaveEntity(pointer);
            }
        }

        protected override ITextLabel BuildEntity(IntPtr entityPointer)
        {
            return new TextLabel(entityPointer, _plugin);
        }
    }
}
