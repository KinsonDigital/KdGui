// <copyright file="FakeButton.cs" company="KinsonDigital">
// Copyright (c) KinsonDigital. All rights reserved.
// </copyright>

namespace KdGuiTests.Helpers;

using System.Drawing;
using KdGui;

public class FakeButton : IControl
{
    public void Dispose() => throw new NotImplementedException();

    public string Name { get; set; }

    public Guid WindowOwnerId { get; set; }

    public Point Position { get; set; }

    public int Width { get; }

    public int Height { get; }

    public bool Enabled { get; set; }

    public bool Visible { get; set; }
}
