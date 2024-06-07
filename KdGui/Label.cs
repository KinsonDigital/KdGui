// <copyright file="Label.cs" company="KinsonDigital">
// Copyright (c) KinsonDigital. All rights reserved.
// </copyright>

namespace KdGui;

using Core;
using Carbonate.NonDirectional;

/// <inheritdoc cref="ILabel"/>
internal sealed class Label : Control, ILabel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Label"/> class.
    /// </summary>
    /// <param name="imGuiInvoker">Invokes ImGui functions.</param>
    /// <param name="renderReactable">Manages render notifications.</param>
    public Label(IImGuiInvoker imGuiInvoker, IPushReactable renderReactable)
        : base(imGuiInvoker, renderReactable)
    {
    }

    /// <inheritdoc/>
    public string Text { get; set; } = "Label";

    /// <inheritdoc/>
    protected override void Render()
    {
        if (!Visible)
        {
            return;
        }

        ImGuiInvoker.Text(Text);
    }
}
