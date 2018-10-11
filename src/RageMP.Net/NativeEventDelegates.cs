using System;

namespace RageMP.Net
{
    public delegate void NativeTickDelegate();

    public delegate void NativeEntityCreatedDelegate(IntPtr entityPointer);
    public delegate void NativeEntityDestroyedDelegate(IntPtr entityPointer);
    public delegate void NativeEntityModelChangeDelegate(IntPtr entityPointer, uint oldModel);

    public delegate void NativePlayerJoinDelegate(IntPtr playerPointer);
    public delegate void NativePlayerReadyDelegate(IntPtr playerPointer);
    public delegate void NativePlayerQuitDelegate(IntPtr playerPointer, uint type, string reason);
    public delegate void NativePlayerCommandDelegate(IntPtr playerPointer, IntPtr text);
    public delegate void NativePlayerChatDelegate(IntPtr playerPointer, IntPtr text);
    public delegate void NativePlayerDeathDelegate(IntPtr playerPointer, uint reason, IntPtr killerPlayerPointer);
    public delegate void NativePlayerSpawnDelegate(IntPtr playerPointer);
    public delegate void NativePlayerDamageDelegate(IntPtr playerPointer, float healthLoss, float armorLoss);
    public delegate void NativePlayerWeaponChangeDelegate(IntPtr playerPointer, uint oldWeapon, uint newWeapon);
    //public delegate void NativePlayerRemoteEventDelegate(IntPtr playerPointer, uint eventNameHash, object[] arguments);
    public delegate void NativePlayerStartEnterVehicleDelegate(IntPtr playerPointer, IntPtr vehiclePointer, uint seat);
    public delegate void NativePlayerEnterVehicleDelegate(IntPtr playerPointer, IntPtr vehiclePointer, uint seat);
    public delegate void NativePlayerStartExitVehicleDelegate(IntPtr playerPointer, IntPtr vehiclePointer);
    public delegate void NativePlayerExitVehicleDelegate(IntPtr playerPointer, IntPtr vehiclePointer);

    public delegate void NativeVehicleDeathDelegate(IntPtr vehiclePointer, uint reason, IntPtr killerPlayerPointer);
    public delegate void NativeVehicleSirenToggleDelegate(IntPtr vehiclePointer, bool toggle);
    public delegate void NativeVehicleHornDelegate(IntPtr vehiclePointer, bool toggle);
    public delegate void NativeVehicleTrailerAttachedDelegate(IntPtr vehiclePointer, IntPtr trailerPointer);
    public delegate void NativeVehicleDamageDelegateDelegate(IntPtr vehiclePointer, float bodyHealthLoss, float engineHealthLoss);

    public delegate void NativePlayerEnterColshapeDelegate(IntPtr playerPointer, IntPtr colshapePointer);
    public delegate void NativePlayerExitColshapeDelegate(IntPtr playerPointer, IntPtr colshapePointer);

    public delegate void NativePlayerEnterCheckpointDelegate(IntPtr playerPointer, IntPtr checkpointPointer);
    public delegate void NativePlayerExitCheckpointDelegate(IntPtr playerPointer, IntPtr checkpointPointer);

    //public delegate void NativeCreateWaypointDelegate(IntPtr playerPointer/**, Vector3 position (?) **/);
    public delegate void NativeReachWaypointDelegate(IntPtr playerPointer);

    public delegate void NativePlayerStreamInDelegate(IntPtr playerPointer, IntPtr forPlayerPointer);
    public delegate void NativePlayerStreamOutDelegate(IntPtr playerPointer, IntPtr forPlayerPointer);
}
