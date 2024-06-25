// <copyright file="ControlFactory.cs" company="KinsonDigital">
// Copyright (c) KinsonDigital. All rights reserved.
// </copyright>

namespace KdGui.Factories;

/// <inheritdoc/>
public class ControlFactory : IControlFactory
{
    /// <inheritdoc/>
    public IControlGroup CreateControlGroup() => IoC.Container.GetInstance<IControlGroup>();

    /// <inheritdoc/>
    public IButton CreateButton() => IoC.Container.GetInstance<IButton>();

    /// <inheritdoc/>
    public ILabel CreateLabel() => IoC.Container.GetInstance<ILabel>();

    /// <inheritdoc/>
    public IArrowButton CreateArrowButton() => IoC.Container.GetInstance<IArrowButton>();

    /// <inheritdoc/>
    public ICheckBox CreateCheckbox() => IoC.Container.GetInstance<ICheckBox>();

    /// <inheritdoc/>
    public IRadioButton CreateRadioButton() => IoC.Container.GetInstance<IRadioButton>();

    /// <inheritdoc/>
    public ISlider CreateSlider() => IoC.Container.GetInstance<ISlider>();

    /// <inheritdoc/>
    public IUpDown CreateUpDown() => IoC.Container.GetInstance<IUpDown>();

    /// <inheritdoc/>
    public IComboBox CreateComboBox() => IoC.Container.GetInstance<IComboBox>();

    /// <inheritdoc/>
    public INextPrevious CreateNextPrevious() => IoC.Container.GetInstance<INextPrevious>();
}
