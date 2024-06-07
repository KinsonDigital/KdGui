// <copyright file="IControlFactory.cs" company="KinsonDigital">
// Copyright (c) KinsonDigital. All rights reserved.
// </copyright>

namespace KdGui.Factories;

/// <summary>
/// Creates various UI controls.
/// </summary>
public interface IControlFactory
{
    /// <summary>
    /// Creates a control group.
    /// </summary>
    /// <returns>The new control group.</returns>
    IControlGroup CreateControlGroup();

    /// <summary>
    /// Creates a button control.
    /// </summary>
    /// <returns>The new button.</returns>
    IButton CreateButton();

    /// <summary>
    /// Creates a label control.
    /// </summary>
    /// <returns>The new label.</returns>
    ILabel? CreateLabel();

    /// <summary>
    /// Creates an arrow button control.
    /// </summary>
    /// <returns>The new arrow button.</returns>
    IArrowButton? CreateArrowButton();

    /// <summary>
    /// Creates a checkbox control.
    /// </summary>
    /// <returns>The new checkbox.</returns>
    ICheckBox? CreateCheckbox();

    /// <summary>
    /// Creates a radio button control.
    /// </summary>
    /// <returns>The new radio button.</returns>
    IRadioButton? CreateRadioButton();

    /// <summary>
    /// Creates a slider control.
    /// </summary>
    /// <returns>The new slider.</returns>
    ISlider? CreateSlider();

    /// <summary>
    /// Creates an up down control.
    /// </summary>
    /// <returns>The new up down.</returns>
    IUpDown? CreateUpDown();

    /// <summary>
    /// Creates a combobox control.
    /// </summary>
    /// <returns>The new combobox.</returns>
    IComboBox? CreateComboBox();

    /// <summary>
    /// Creates a next previous control.
    /// </summary>
    /// <returns>The new next previous.</returns>
    INextPrevious? CreateNextPrevious();
}
