using System;
using System.Numerics;
using RageMP.Net.Data;
using RageMP.Net.Entities;
using RageMP.Net.Helpers;
using RageMP.Net.Interfaces;
using RageMP.Net.Native;

namespace RageMP.Net.Scripting.ScriptingClasses
{
    internal class TextLabelPool : PoolBase<ITextLabel>, ITextLabelPool
    {
        public TextLabelPool(IntPtr nativePointer) : base(nativePointer)
        {
        }

        public ITextLabel New(Vector3 position, string text, uint font, ColorRgba color, float drawDistance, bool los, uint dimension)
        {
            using (var converter = new StringConverter())
            {
                var pointer = Rage.TextLabelPool.TextLabelPool_New(_nativePointer, position, converter.StringToPointer(text), font, color, drawDistance, los, dimension);

                return new TextLabel(pointer);
            }
        }
    }
}
