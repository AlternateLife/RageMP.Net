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
        public TextLabelPool(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin)
        {
        }

        public ITextLabel New(Vector3 position, string text, uint font, ColorRgba color, float drawDistance, bool los, uint dimension)
        {
            using (var converter = new StringConverter())
            {
                var pointer = Rage.TextLabelPool.TextLabelPool_New(_nativePointer, position, converter.StringToPointer(text), font, color, drawDistance, los, dimension);

                return CreateAndSaveEntity(pointer);
            }
        }

        protected override ITextLabel BuildEntity(IntPtr entityPointer)
        {
            return new TextLabel(entityPointer, _plugin);
        }
    }
}
