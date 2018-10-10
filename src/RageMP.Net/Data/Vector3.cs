using System.Runtime.InteropServices;

namespace RageMP.Net.Data
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public System.Numerics.Vector3 ToNumericsVector()
        {
            return new System.Numerics.Vector3(X, Y, Z);
        }

        public static Vector3 FromNumericsVector(System.Numerics.Vector3 other)
        {
            return new Vector3(other.X, other.Y, other.Z);
        }
    }
}
