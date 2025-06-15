using Content.Shared.AaCustom.Components;
using JetBrains.Annotations;
using static Content.Shared.AaCustom.Components.SharedTwoButtonPanelComponent;

namespace Content.Client.AaCustom.UI;

[UsedImplicitly]
public sealed class TwoButtonPanelBoundUserInterface : BoundUserInterface
{

    [ViewVariables]
    public TwoButtonPanelWindow? TestWindow;

    public TwoButtonPanelBoundUserInterface(EntityUid owner, Enum uiKey) : base(owner, uiKey)
    {
    }

    private void ButtonPressed(UiButton button)
    {
        SendMessage(new UiButtonPressedMessage(button));
    }


    protected override void Open()
    {
        base.Open();
        if (UiKey is TwoButtonPanelUiKey)
        {
            TestWindow = new TwoButtonPanelWindow();
            TestWindow.OpenCenteredRight();
            TestWindow.OnClose += Close;

            TestWindow.Button1.OnPressed += _ => ButtonPressed(UiButton.Button1);
            TestWindow.Button2.OnPressed += _ => ButtonPressed(UiButton.Button2);
        }
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        if (!disposing)
            return;

        TestWindow?.Dispose();
    }
}
