using System;
using System.Numerics;
using RageMP.Net.Data;

namespace RageMP.Net
{
    internal delegate void NativeTickDelegate();

    internal delegate void NativeEntityCreatedDelegate(IntPtr entityPointer);
    internal delegate void NativeEntityDestroyedDelegate(IntPtr entityPointer);
    internal delegate void NativeEntityModelChangeDelegate(IntPtr entityPointer, uint oldModel);

    internal delegate void NativePlayerJoinDelegate(IntPtr playerPointer);
    internal delegate void NativePlayerReadyDelegate(IntPtr playerPointer);
    internal delegate void NativePlayerQuitDelegate(IntPtr playerPointer, uint type, IntPtr reason);
    internal delegate void NativePlayerCommandDelegate(IntPtr playerPointer, IntPtr text);
    internal delegate void NativePlayerChatDelegate(IntPtr playerPointer, IntPtr text);
    internal delegate void NativePlayerDeathDelegate(IntPtr playerPointer, uint reason, IntPtr killerPlayerPointer);
    internal delegate void NativePlayerSpawnDelegate(IntPtr playerPointer);
    internal delegate void NativePlayerDamageDelegate(IntPtr playerPointer, float healthLoss, float armorLoss);
    internal delegate void NativePlayerWeaponChangeDelegate(IntPtr playerPointer, uint oldWeapon, uint newWeapon);
    //internal delegate void NativePlayerRemoteEventDelegate(IntPtr playerPointer, uint eventNameHash, object[] arguments);
    internal delegate void NativePlayerStartEnterVehicleDelegate(IntPtr playerPointer, IntPtr vehiclePointer, uint seat);
    internal delegate void NativePlayerEnterVehicleDelegate(IntPtr playerPointer, IntPtr vehiclePointer, uint seat);
    internal delegate void NativePlayerStartExitVehicleDelegate(IntPtr playerPointer, IntPtr vehiclePointer);
    internal delegate void NativePlayerExitVehicleDelegate(IntPtr playerPointer, IntPtr vehiclePointer);

    internal delegate void NativeVehicleDeathDelegate(IntPtr vehiclePointer, uint reason, IntPtr killerPlayerPointer);
    internal delegate void NativeVehicleSirenToggleDelegate(IntPtr vehiclePointer, bool toggle);
    internal delegate void NativeVehicleHornToggleDelegate(IntPtr vehiclePointer, bool toggle);
    internal delegate void NativeVehicleTrailerAttachedDelegate(IntPtr vehiclePointer, IntPtr trailerPointer);
    internal delegate void NativeVehicleDamageDelegate(IntPtr vehiclePointer, float bodyHealthLoss, float engineHealthLoss);

    internal delegate void NativePlayerEnterColshapeDelegate(IntPtr playerPointer, IntPtr colshapePointer);
    internal delegate void NativePlayerExitColshapeDelegate(IntPtr playerPointer, IntPtr colshapePointer);

    internal delegate void NativePlayerEnterCheckpointDelegate(IntPtr playerPointer, IntPtr checkpointPointer);
    internal delegate void NativePlayerExitCheckpointDelegate(IntPtr playerPointer, IntPtr checkpointPointer);

    internal delegate void NativePlayerCreateWaypointDelegate(IntPtr playerPointer, Vector3 position);
    internal delegate void NativePlayerReachWaypointDelegate(IntPtr playerPointer);

    internal delegate void NativePlayerStreamInDelegate(IntPtr playerPointer, IntPtr forPlayerPointer);
    internal delegate void NativePlayerStreamOutDelegate(IntPtr playerPointer, IntPtr forPlayerPointer);

    internal delegate void NativePlayerRemoteEventDelegate(IntPtr playerPointer, ArgumentsData arguments);
}
