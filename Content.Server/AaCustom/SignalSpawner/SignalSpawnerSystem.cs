using Content.Server.DeviceLinking.Systems;
using Content.Shared.DeviceLinking.Events;

namespace Content.Server.AaCustom.SignalSpawner;

/// <summary>
/// This handles...
/// </summary>
public sealed class SignalSpawnerSystem : EntitySystem
{
    [Dependency] private readonly ILogManager _logManager = default!;

    private ISawmill _sawmill = default!;

    /// <inheritdoc/>
    public override void Initialize()
    {
        base.Initialize();

        _sawmill=_logManager.GetSawmill("MonkeySpawner");

        SubscribeLocalEvent<SignalSpawnerComponent,SignalReceivedEvent>(OnSignal);
    }

    private void OnSignal(EntityUid uid, SignalSpawnerComponent component, SignalReceivedEvent args)
    {
        if (args.Port == component.TriggerPort)
        {
            EntityManager.SpawnEntity(component.Spawn, Transform(uid).Coordinates);
        }
    }
}
