﻿using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.CustomControls;
using Robust.Client.UserInterface.XAML;

namespace Content.Client.AaCustom.UI;

[GenerateTypedNameReferences]
public sealed partial class TwoButtonPanelWindow : DefaultWindow
{
    public TwoButtonPanelWindow()
    {
        RobustXamlLoader.Load(this);
        Title = "Two button panel";

    }
}
