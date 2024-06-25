// <copyright file="ControlGroupTests.cs" company="KinsonDigital">
// Copyright (c) KinsonDigital. All rights reserved.
// </copyright>

namespace KdGuiTests;

using System.Drawing;
using Carbonate.NonDirectional;
using FluentAssertions;
using Helpers;
using KdGui;
using KdGui.Core;
using NSubstitute;

/// <summary>
/// Tests the <see cref="ControlGroup"/> class.
/// </summary>
public class ControlGroupTests
{
    private readonly IImGuiInvoker mockImGuiInvoker;
    private readonly IPushReactable mockPushReactable;

    /// <summary>
    /// Initializes a new instance of the <see cref="ControlGroupTests"/> class.
    /// </summary>
    public ControlGroupTests()
    {
        this.mockImGuiInvoker = Substitute.For<IImGuiInvoker>();
        this.mockPushReactable = Substitute.For<IPushReactable>();
    }

    #region Constructor Tests
    [Fact]
    public void Ctor_WithNullImGuiInvokerParam_ThrowsException()
    {
        // Arrange & Act
        var act = () =>
        {
            _ = new ControlGroup(null, this.mockPushReactable);
        };

        // Assert
        act.Should()
            .Throw<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'imGuiInvoker')");
    }

    [Fact]
    public void Ctor_WithNullRenderReactableParam_ThrowsException()
    {
        // Arrange & Act
        var act = () =>
        {
            _ = new ControlGroup(this.mockImGuiInvoker, null);
        };

        // Assert
        act.Should()
            .Throw<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'renderReactable')");
    }

    [Fact]
    public void Ctor_WhenInvoked_SetsIdProperty()
    {
        // Arrange
        var sut = CreateSystemUnderTest();

        // Act
        var actual = sut.Id;

        // Assert
        actual.Should().NotBeEmpty();
    }
    #endregion

    #region Prop Tests
    [Fact]
    public void Title_WhenSettingValue_ReturnsCorrectResult()
    {
        // Arrange
        var sut = CreateSystemUnderTest();

        // Act
        sut.Title = "test";

        // Assert
        sut.Title.Should().Be("test");
    }

    [Fact]
    public void Position_WhenSettingValue_ReturnsCorrectResult()
    {
        // Arrange
        var sut = CreateSystemUnderTest();

        // Act
        sut.Position = new Point(10, 20);

        // Assert
        sut.Position.Should().Be(new Point(10, 20));
    }

    [Fact]
    public void Width_WhenSettingValue_ReturnsCorrectResult()
    {
        // Arrange
        var sut = CreateSystemUnderTest();

        // Act
        sut.Width = 100;

        // Assert
        sut.Width.Should().Be(100);
    }

    [Fact]
    public void Height_WhenSettingValue_ReturnsCorrectResult()
    {
        // Arrange
        var sut = CreateSystemUnderTest();

        // Act
        sut.Height = 100;

        // Assert
        sut.Height.Should().Be(100);
    }

    [Fact]
    public void HalfWidth_WhenGettingValue_ReturnsCorrectResult()
    {
        // Arrange
        var sut = CreateSystemUnderTest();

        // Act
        sut.Width = 100;

        // Assert
        sut.HalfWidth.Should().Be(50);
    }

    [Fact]
    public void HalfHeight_WhenGettingValue_ReturnsCorrectResult()
    {
        // Arrange
        var sut = CreateSystemUnderTest();

        // Act
        sut.Height = 100;

        // Assert
        sut.HalfHeight.Should().Be(50);
    }

    [Fact]
    public void Left_WhenGettingValue_ReturnsCorrectResult()
    {
        // Arrange
        var sut = CreateSystemUnderTest();

        // Act
        sut.Position = new Point(10, 20);

        // Assert
        sut.Left.Should().Be(10);
    }

    [Fact]
    public void Top_WhenGettingValue_ReturnsCorrectResult()
    {
        // Arrange
        var sut = CreateSystemUnderTest();

        // Act
        sut.Position = new Point(10, 20);

        // Assert
        sut.Top.Should().Be(20);
    }

    [Fact]
    public void Right_WhenGettingValue_ReturnsCorrectResult()
    {
        // Arrange
        var sut = CreateSystemUnderTest();

        // Act
        sut.Position = new Point(10, 20);
        sut.Width = 100;

        // Assert
        sut.Right.Should().Be(110);
    }

    [Fact]
    public void Bottom_WhenGettingValue_ReturnsCorrectResult()
    {
        // Arrange
        var sut = CreateSystemUnderTest();

        // Act
        sut.Position = new Point(10, 20);
        sut.Height = 100;

        // Assert
        sut.Bottom.Should().Be(120);
    }

    [Fact]
    public void TitleBarVisible_WhenSettingValue_ReturnsCorrectResult()
    {
        // Arrange
        var sut = CreateSystemUnderTest();
        var expected = !sut.TitleBarVisible;

        // Act
        sut.TitleBarVisible = !sut.TitleBarVisible;

        // Assert
        sut.TitleBarVisible.Should().Be(expected);
    }

    [Fact]
    public void AutoSizeToFitContent_WhenSettingValue_ReturnsCorrectResult()
    {
        // Arrange
        var sut = CreateSystemUnderTest();
        var expected = !sut.AutoSizeToFitContent;

        // Act
        sut.AutoSizeToFitContent = !sut.AutoSizeToFitContent;

        // Assert
        sut.AutoSizeToFitContent.Should().Be(expected);
    }

    [Fact]
    public void NoResize_WhenSettingValue_ReturnsCorrectResult()
    {
        // Arrange
        var sut = CreateSystemUnderTest();
        var expected = !sut.NoResize;

        // Act
        sut.NoResize = !sut.NoResize;

        // Assert
        sut.NoResize.Should().Be(expected);
    }

    [Fact]
    public void Visible_WhenSettingValue_ReturnsCorrectResult()
    {
        // Arrange
        var sut = CreateSystemUnderTest();
        var expected = !sut.Visible;

        // Act
        sut.Visible = !sut.Visible;

        // Assert
        sut.Visible.Should().Be(expected);
    }
    #endregion

    #region Method Tests
    [Fact]
    public void AddAndGetControl_WhenAddingControl_AddsControl()
    {
        // Arrange
        var fakeBtn = new FakeButton();
        fakeBtn.Name = "fake-button";

        var fakeLabel = new FakeLabel();
        fakeLabel.Name = "fake-label";

        var sut = CreateSystemUnderTest();
        sut.Add(fakeBtn);
        sut.Add(fakeLabel);

        // Act
        var actualFakeBtn = sut.GetControl<IControl>("fake-button");
        var actualFakeLabel = sut.GetControl<IControl>("fake-label");

        // Assert
        actualFakeBtn.Should().NotBeNull();
        actualFakeBtn.Should().BeOfType<FakeButton>();
        actualFakeBtn.Name.Should().Be("fake-button");

        actualFakeLabel.Should().NotBeNull();
        actualFakeLabel.Should().BeOfType<FakeLabel>();
        actualFakeLabel.Name.Should().Be("fake-label");
    }
    #endregion

    /// <summary>
    /// Creates a new instance of <see cref="ControlGroup"/> for the purpose of testing.
    /// </summary>
    /// <returns>The instance to test.</returns>
    private ControlGroup CreateSystemUnderTest()
        => new (this.mockImGuiInvoker, this.mockPushReactable);
}
