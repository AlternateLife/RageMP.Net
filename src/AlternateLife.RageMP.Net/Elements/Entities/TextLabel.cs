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

        public async Task SetColorAsync(Color value)
        {
            CheckExistence();

            await _plugin.Schedule(() => Rage.TextLabel.TextLabel_SetColor(NativePointer, value.ToModColor())).ConfigureAwait(false);
        }

        public async Task<Color> GetColorAsync()
        {
            CheckExistence();

            return await _plugin.Schedule(() => StructConverter.PointerToStruct<ColorRgba>(Rage.TextLabel.TextLabel_GetColor(NativePointer)).FromModColor()).ConfigureAwait(false);
        }

        public async Task SetTextAsync(string value)
        {
            Contract.NotNull(value, nameof(value));

            using (var converter = new StringConverter())
            {
                var text = converter.StringToPointer(value);

                await _plugin.Schedule(() => Rage.TextLabel.TextLabel_SetText(NativePointer, text)).ConfigureAwait(false);
            }
        }

        public async Task<string> GetTextAsync()
        {
            CheckExistence();

            return await _plugin.Schedule(() => StringConverter.PointerToString(Rage.TextLabel.TextLabel_GetText(NativePointer))).ConfigureAwait(false);
        }

        public async Task SetLOSAsync(bool value)
        {
            CheckExistence();

            await _plugin.Schedule(() => Rage.TextLabel.TextLabel_SetLOS(NativePointer, value)).ConfigureAwait(false);
        }

        public async Task<bool> GetLOSAsync()
        {
            CheckExistence();

            return await _plugin.Schedule(() => Rage.TextLabel.TextLabel_GetLOS(NativePointer)).ConfigureAwait(false);
        }

        public async Task SetDrawDistanceAsync(float value)
        {
            CheckExistence();

            await _plugin.Schedule(() => Rage.TextLabel.TextLabel_SetDrawDistance(NativePointer, value)).ConfigureAwait(false);
        }

        public async Task<float> GetDrawDistanceAsync()
        {
            CheckExistence();

            return await _plugin.Schedule(() => Rage.TextLabel.TextLabel_GetDrawDistance(NativePointer)).ConfigureAwait(false);
        }

        public async Task SetFontAsync(uint value)
        {
            CheckExistence();

            await _plugin.Schedule(() => Rage.TextLabel.TextLabel_SetFont(NativePointer, value)).ConfigureAwait(false);
        }

        public async Task<uint> GetFontAsync()
        {
            CheckExistence();

            return await _plugin.Schedule(() => Rage.TextLabel.TextLabel_GetFont(NativePointer)).ConfigureAwait(false);
        }

    }
}
