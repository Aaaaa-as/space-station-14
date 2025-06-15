using Robust.Shared.GameStates;
using Robust.Shared.Serialization;

namespace Content.Shared.AaCustom.Components;

/// <summary>
/// This is used for...
/// </summary>
[NetworkedComponent]
public abstract partial class SharedTwoButtonPanelComponent : Component
{


    [Serializable, NetSerializable]
    public enum UiButton : byte
    {
        Button1,
        Button2,
    }

    [Serializable, NetSerializable]
    public sealed class UiButtonPressedMessage : BoundUserInterfaceMessage
    {
        public readonly UiButton Button;

        public UiButtonPressedMessage(UiButton button)
        {
            Button = button;
        }
    }

    [Serializable, NetSerializable]
    public enum TwoButtonPanelUiKey : byte
    {
        Key
    }


}
