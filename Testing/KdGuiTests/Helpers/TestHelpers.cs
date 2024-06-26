// <copyright file="TestHelpers.cs" company="KinsonDigital">
// Copyright (c) KinsonDigital. All rights reserved.
// </copyright>

namespace KdGuiTests.Helpers;

using System.Reflection;
using FluentAssertions;

/// <summary>
/// Provides testing helpers.
/// </summary>
public static class TestHelpers
{
    /// <summary>
    /// Sets a field with a name that matches the given <paramref name="fieldName"/> to the value of null.
    /// </summary>
    /// <param name="fieldContainer">The object that contains the field.</param>
    /// <param name="fieldName">The name of the field.</param>
    /// <param name="value">The value to set the field to.</param>
    /// <typeparam name="T">The type of parameter.</typeparam>
    public static void SetFieldValue<T>(this object fieldContainer, string fieldName, T value)
    {
        fieldContainer.Should().NotBeNull("setting the field value of a null object is not possible.");
        fieldName.Should().NotBeNullOrEmpty("setting an field value requires a non-empty or null field name.");

        var fields = fieldContainer.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

        fields.Should().HaveCountGreaterThan(0, $"no fields exist in the object.");

        var foundField = Array.Find(fields, f => f.Name == fieldName);

        foundField.Should().NotBeNull($"a field with the name '{fieldName}' does not exist in the object.");
        foundField.FieldType.Should().Be(typeof(T), "the generic type should match the actual field type.");

        foundField.SetValue(fieldContainer, value);
    }
}
