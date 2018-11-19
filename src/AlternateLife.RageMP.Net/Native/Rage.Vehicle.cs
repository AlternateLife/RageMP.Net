using System;
using System.Numerics;
using System.Runtime.InteropServices;
using AlternateLife.RageMP.Net.Data;

namespace AlternateLife.RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class Vehicle
        {
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Vehicle_IsHornActive(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Vehicle_IsRocketBoostActive(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Vehicle_IsBreakActive(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Vehicle_IsSirenActive(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetSirenActive(IntPtr vehicle, bool newStatus);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Vehicle_AreHighbeamsActive(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetHighbeamsActive(IntPtr vehicle, bool newStatus);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Vehicle_AreLightsActive(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetLightsActive(IntPtr vehicle, bool newStatus);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Vehicle_AreTaxiLightsActive(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetTaxiLightsActive(IntPtr vehicle, bool newStatus);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Vehicle_AreNeonsActive(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_EnableNeons(IntPtr vehicle, bool newStatus);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Vehicle_IsEngineActive(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetEngineActive(IntPtr vehicle, bool newStatus);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Vehicle_IsLocked(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetLocked(IntPtr vehicle, bool newStatus);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Vehicle_IsDead(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern float Vehicle_GetSteerAngle(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern float Vehicle_GetGasPedalState(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern float Vehicle_GetEngineHealth(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern float Vehicle_GetBodyHealth(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern IntPtr Vehicle_GetOccupant(IntPtr vehicle, int seat);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_GetOccupants(IntPtr vehicle, out IntPtr players, out ulong size);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetOccupant(IntPtr vehicle, int seat, IntPtr player);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_Explode(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_Repair(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern uint Vehicle_GetMod(IntPtr vehicle, uint id);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetMod(IntPtr vehicle, uint id, uint mod);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetNeonsColor(IntPtr vehicle, uint red, uint green, uint blue);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern IntPtr Vehicle_GetNeonsColor(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern uint Vehicle_GetColor(IntPtr vehicle, uint id);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern uint Vehicle_GetPaint(IntPtr vehicle, uint id);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetColor(IntPtr vehicle, uint primaryColor, uint secondaryColor);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetColorRGB(IntPtr vehicle, ColorRgba primaryColor, ColorRgba secondaryColor);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern IntPtr Vehicle_GetColorRGB(IntPtr vehicle, uint id);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetPaint(IntPtr vehicle, PaintData primaryPaint, PaintData secondaryPaint);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern uint Vehicle_GetMaterialType(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern IntPtr Vehicle_GetNumberPlate(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetNumberPlate(IntPtr vehicle, IntPtr numberPlate);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Vehicle_IsStreamed(IntPtr vehicle, IntPtr player);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_GetStreamed(IntPtr vehicle, out IntPtr players, out ulong count);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern uint Vehicle_GetLivery(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetLivery(IntPtr vehicle, uint livery);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern uint Vehicle_GetWheelColor(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetWheelColor(IntPtr vehicle, uint color);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern uint Vehicle_GetWheelType(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetWheelType(IntPtr vehicle, uint type);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern uint Vehicle_GetNumberPlateType(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetNumberPlateType(IntPtr vehicle, uint type);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern uint Vehicle_GetPearlescentColor(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetPearlescentColor(IntPtr vehicle, uint color);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern uint Vehicle_GetWindowTint(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetWindowTint(IntPtr vehicle, uint tint);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern uint Vehicle_GetDashboardColor(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetDashboardColor(IntPtr vehicle, uint color);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern uint Vehicle_GetTrimColor(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetTrimColor(IntPtr vehicle, uint color);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Vehicle_GetExtra(IntPtr vehicle, uint id);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetExtra(IntPtr vehicle, uint id, bool state);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern float Vehicle_GetMovableState(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern float Vehicle_GetHeading(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern IntPtr Vehicle_GetTrailer(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern IntPtr Vehicle_GetTraileredBy(IntPtr vehicle);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_Spawn(IntPtr vehicle, Vector3 position, float heading);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern IntPtr Vehicle_GetQuaternion(IntPtr vehicle);


        }
    }
}
