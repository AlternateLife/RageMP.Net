using System.Runtime.InteropServices;

namespace AlternateLife.RageMP.Net.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct HeadBlendData
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public readonly byte[] Shape;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public readonly byte[] Skin;

        public readonly float ShapeMix;
        public readonly float SkinMix;
        public readonly float ThirdMix;

        public HeadBlendData(byte shapeFirst, byte shapeSecond, byte shapeThird, byte skinFirst, byte skinSecond, byte skinThird, float shapeMix, float skinMix, float thirdMix)
        {
            Shape = new[] {shapeFirst, shapeSecond, shapeThird};
            Skin = new[] {skinFirst, skinSecond, skinThird};

            ShapeMix = shapeMix;
            SkinMix = skinMix;
            ThirdMix = thirdMix;
        }
    }
}
