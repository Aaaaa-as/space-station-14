using Content.Shared.DeviceLinking;
using Robust.Shared.Prototypes;

namespace Content.Server.AaCustom.SignalSpawner;

/// <summary>
/// This is used for...
/// </summary>
[RegisterComponent]
public sealed partial class SignalSpawnerComponent : Component
{
    [DataField, ViewVariables]
    public ProtoId<SinkPortPrototype> TriggerPort = "Trigger";

    [DataField,ViewVariables(VVAccess.ReadWrite)]
    public EntProtoId Spawn;
}
