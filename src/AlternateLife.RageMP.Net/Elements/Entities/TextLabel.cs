using System;
using System.Drawing;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Extensions;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Entities
{
    internal class TextLabel : Entity, ITextLabel
    {

        internal TextLabel(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin, EntityType.TextLabel)
        {
        }

        public void SetColor(Color value)
        {
            CheckExistence();

            Rage.TextLabel.TextLabel_SetColor(NativePointer, value.GetNumberValue());
        }

        public Task SetColorAsync(Color value)
        {
            return _plugin.Schedule(() => SetColor(value));
        }

        public Color GetColor()
        {
            CheckExistence();

            return StructConverter.PointerToStruct<ColorRgba>(Rage.TextLabel.TextLabel_GetColor(NativePointer)).FromModColor();
        }

        public Task<Color> GetColorAsync()
        {
            return _plugin.Schedule(GetColor);
        }

        public void SetText(string value)
        {
            Contract.NotNull(value, nameof(value));

            using (var converter = new StringConverter())
            {
                var text = converter.StringToPointer(value);

                Rage.TextLabel.TextLabel_SetText(NativePointer, text);
            }
        }

        public Task SetTextAsync(string value)
        {
            return _plugin.Schedule(() => SetText(value));
        }

        public string GetText()
        {
            CheckExistence();

            return StringConverter.PointerToString(Rage.TextLabel.TextLabel_GetText(NativePointer));
        }

        public Task<string> GetTextAsync()
        {
            return _plugin.Schedule(GetText);
        }

        public void SetLOS(bool value)
        {
            CheckExistence();

            Rage.TextLabel.TextLabel_SetLOS(NativePointer, value);
        }

        public Task SetLOSAsync(bool value)
        {
            return _plugin.Schedule(() => SetLOS(value));
        }

        public bool GetLOS()
        {
            CheckExistence();

            return Rage.TextLabel.TextLabel_GetLOS(NativePointer);
        }

        public Task<bool> GetLOSAsync()
        {
            return _plugin.Schedule(GetLOS);
        }

        public void SetDrawDistance(float value)
        {
            CheckExistence();

            Rage.TextLabel.TextLabel_SetDrawDistance(NativePointer, value);
        }

        public Task SetDrawDistanceAsync(float value)
        {
            return _plugin.Schedule(() => SetDrawDistance(value));
        }

        public float GetDrawDistance()
        {
            CheckExistence();

            return Rage.TextLabel.TextLabel_GetDrawDistance(NativePointer);
        }

        public Task<float> GetDrawDistanceAsync()
        {
            return _plugin
                .Schedule(GetDrawDistance);
        }

        public void SetFont(uint value)
        {
            CheckExistence();

            Rage.TextLabel.TextLabel_SetFont(NativePointer, value);
        }

        public Task SetFontAsync(uint value)
        {
            return _plugin.Schedule(() => SetFont(value));
        }

        public uint GetFont()
        {
            CheckExistence();

            return Rage.TextLabel.TextLabel_GetFont(NativePointer);
        }

        public Task<uint> GetFontAsync()
        {
            return _plugin.Schedule(GetFont);
        }

    }
}
