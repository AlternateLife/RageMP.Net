namespace RageMP.Net.Data
{
    public struct HeadBlendData
    {
        public byte ShapeFirst { get; set; }
        public byte ShapeSecond { get; set; }
        public byte ShapeThird { get; set; }

        public byte SkinFirst { get; set; }
        public byte SkinSecond { get; set; }
        public byte SkinThird { get; set; }

        public float ShapeMix { get; set; }
        public float SkinMix { get; set; }
        public float ThirdMix { get; set; }

        public HeadBlendData(byte shapeFirst, byte shapeSecond, byte shapeThird, byte skinFirst, byte skinSecond, byte skinThird, float shapeMix, float skinMix, float thirdMix)
        {
            ShapeFirst = shapeFirst;
            ShapeSecond = shapeSecond;
            ShapeThird = shapeThird;

            SkinFirst = skinFirst;
            SkinSecond = skinSecond;
            SkinThird = skinThird;

            ShapeMix = shapeMix;
            SkinMix = skinMix;
            ThirdMix = thirdMix;
        }
    }
}
