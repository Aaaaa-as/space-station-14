using Content.Server.AaCustom.Components;
using Content.Server.DeviceLinking.Systems;
using Content.Shared.AaCustom.Components;
using Content.Shared.AaCustom.Systems;
using Content.Shared.Disposal.Components;
using Content.Shared.Interaction;
using Robust.Server.GameObjects;
using Robust.Server.Player;
using Robust.Shared.Player;

namespace Content.Server.AaCustom.Systems;

public sealed class TwoButtonPanelSystem : SharedTwoButtonPanelSystem
{
    [Dependency] private readonly UserInterfaceSystem _ui = default!;
    [Dependency] private readonly DeviceLinkSystem _deviceLink = default!;
    [Dependency] private readonly ILogManager _logManager = default!;

    private ISawmill _sawmill = default!;

    public override void Initialize()
    {
        base.Initialize();

        _sawmill=_logManager.GetSawmill("TestSystem");

        SubscribeLocalEvent<TwoButtonPanelComponent,ActivateInWorldEvent>(OnActivate);

        SubscribeLocalEvent<TwoButtonPanelComponent,SharedTwoButtonPanelComponent.UiButtonPressedMessage>(OnUiButtonPressed);
    }


    private void OnActivate(EntityUid uid, TwoButtonPanelComponent component, ActivateInWorldEvent args)
    {
        if (args.Handled || !args.Complex)
            return;

        if (!TryComp(args.User, out ActorComponent? actor))
        {
            return;
        }

        args.Handled = true;
        _ui.OpenUi(uid, SharedTwoButtonPanelComponent.TwoButtonPanelUiKey.Key, actor.PlayerSession);
    }



    private void OnUiButtonPressed(EntityUid uid,
        TwoButtonPanelComponent component,
        SharedTwoButtonPanelComponent.UiButtonPressedMessage args)
    {
        if (args.Actor is not { Valid: true } player)
        {
            return;
        }

        switch (args.Button)
        {
            case SharedTwoButtonPanelComponent.UiButton.Button1:
                _deviceLink.InvokePort(uid, "Button1Pressed");
                break;
            case SharedTwoButtonPanelComponent.UiButton.Button2:
                _deviceLink.InvokePort(uid, "Button2Pressed");
                break;
        }
    }
}
