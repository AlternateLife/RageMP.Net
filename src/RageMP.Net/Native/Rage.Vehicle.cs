using System;
using System.Runtime.InteropServices;

namespace RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class Vehicle
        {
            [DllImport(_dllName)]
            internal static extern bool Vehicle_IsHornActive(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern bool Vehicle_IsRocketBoostActive(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern bool Vehicle_IsBreakActive(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern bool Vehicle_IsSirenActive(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern void Vehicle_SetSirenActive(IntPtr vehicle, bool newStatus);

            [DllImport(_dllName)]
            internal static extern bool Vehicle_AreHighbeamsActive(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern void Vehicle_SetHighbeamsActive(IntPtr vehicle, bool newStatus);

            [DllImport(_dllName)]
            internal static extern bool Vehicle_AreLightsActive(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern void Vehicle_SetLightsActive(IntPtr vehicle, bool newStatus);

            [DllImport(_dllName)]
            internal static extern bool Vehicle_AreTaxiLightsActive(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern void Vehicle_SetTaxiLightsActive(IntPtr vehicle, bool newStatus);

            [DllImport(_dllName)]
            internal static extern bool Vehicle_AreNeonsActive(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern void Vehicle_SetNeonsActive(IntPtr vehicle, bool newStatus);

            [DllImport(_dllName)]
            internal static extern bool Vehicle_IsEngineActive(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern void Vehicle_SetEngineActive(IntPtr vehicle, bool newStatus);

            [DllImport(_dllName)]
            internal static extern bool Vehicle_IsLocked(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern void Vehicle_SetLocked(IntPtr vehicle, bool newStatus);

            [DllImport(_dllName)]
            internal static extern bool Vehicle_IsDead(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern float Vehicle_GetSteerAngle(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern float Vehicle_GetGasPedalState(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern float Vehicle_GetEngineHealth(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern float Vehicle_GetBodyHealth(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern IntPtr Vehicle_GetOccupant(IntPtr vehicle, uint seat);

            [DllImport(_dllName)]
            internal static extern void Vehicle_SetOccupant(IntPtr vehicle, uint seat, IntPtr player);

            [DllImport(_dllName)]
            internal static extern void Vehicle_Explode(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern void Vehicle_Repair(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern uint Vehicle_GetMod(IntPtr vehicle, uint id);

            [DllImport(_dllName)]
            internal static extern void Vehicle_SetMod(IntPtr vehicle, uint id, uint mod);

            [DllImport(_dllName)]
            internal static extern void Vehicle_SetNeonsColor(IntPtr vehicle, uint red, uint green, uint blue);

            [DllImport(_dllName)]
            internal static extern uint Vehicle_GetColor(IntPtr vehicle, uint id);

            [DllImport(_dllName)]
            internal static extern uint Vehicle_GetPaint(IntPtr vehicle, uint id);

            [DllImport(_dllName)]
            internal static extern void Vehicle_SetColor(IntPtr vehicle, uint primaryColor, uint secondaryColor);

            [DllImport(_dllName)]
            internal static extern uint Vehicle_GetMaterialType(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern IntPtr Vehicle_GetNumberPlate(IntPtr vehicle);

            [DllImport(_dllName, CharSet = CharSet.Ansi)]
            internal static extern void Vehicle_SetNumberPlate(IntPtr vehicle, string numberPlate);

            [DllImport(_dllName)]
            internal static extern bool Vehicle_IsStreamed(IntPtr vehicle, IntPtr player);

            [DllImport(_dllName)]
            internal static extern uint Vehicle_GetLivery(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern void Vehicle_SetLivery(IntPtr vehicle, uint livery);

            [DllImport(_dllName)]
            internal static extern uint Vehicle_GetWheelColor(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern void Vehicle_SetWheelColor(IntPtr vehicle, uint color);

            [DllImport(_dllName)]
            internal static extern uint Vehicle_GetWheelType(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern void Vehicle_SetWheelType(IntPtr vehicle, uint type);

            [DllImport(_dllName)]
            internal static extern uint Vehicle_GetNumberPlateType(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern void Vehicle_SetNumberPlateType(IntPtr vehicle, uint type);

            [DllImport(_dllName)]
            internal static extern uint Vehicle_GetPearlescentColor(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern void Vehicle_SetPearlescentColor(IntPtr vehicle, uint color);

            [DllImport(_dllName)]
            internal static extern uint Vehicle_GetWindowTint(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern void Vehicle_SetWindowTint(IntPtr vehicle, uint tint);

            [DllImport(_dllName)]
            internal static extern uint Vehicle_GetDashboardColor(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern void Vehicle_SetDashboardColor(IntPtr vehicle, uint color);

            [DllImport(_dllName)]
            internal static extern uint Vehicle_GetTrimColor(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern void Vehicle_SetTrimColor(IntPtr vehicle, uint color);

            [DllImport(_dllName)]
            internal static extern bool Vehicle_GetExtra(IntPtr vehicle, uint id);

            [DllImport(_dllName)]
            internal static extern void Vehicle_GetExtra(IntPtr vehicle, uint id, bool state);

            [DllImport(_dllName)]
            internal static extern float Vehicle_GetMovableState(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern float Vehicle_GetHeading(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern IntPtr Vehicle_GetTrailer(IntPtr vehicle);

            [DllImport(_dllName)]
            internal static extern IntPtr Vehicle_GetTraileredBy(IntPtr vehicle);


        }
    }
}
