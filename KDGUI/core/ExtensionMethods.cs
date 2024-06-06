// <copyright file="ExtensionMethods.cs" company="KinsonDigital">
// Copyright (c) KinsonDigital. All rights reserved.
// </copyright>

namespace Core;

using System.Drawing;
using System.Numerics;

internal static class ExtensionMethods
{
    /// <summary>
    /// Maps the given <paramref name="value"/> from one range to another.
    /// </summary>
    /// <param name="value">The value to map.</param>
    /// <param name="fromStart">The from starting range value.</param>
    /// <param name="fromStop">The from ending range value.</param>
    /// <param name="toStart">The to starting range value.</param>
    /// <param name="toStop">The to ending range value.</param>
    /// <returns>A value that has been mapped to a range between <paramref name="toStart"/> and <paramref name="toStop"/>.</returns>
    public static float MapValue(this byte value, float fromStart, float fromStop, float toStart, float toStop)
        => toStart + ((toStop - toStart) * ((value - fromStart) / (fromStop - fromStart)));

    public static Size ToSize(this Vector2 value) => new ((int)value.X, (int)value.Y);

    public static Vector2 ToVector2(this Point value) => new (value.X, value.Y);
    public static Vector2 ToVector2(this Size value) => new (value.Width, value.Height);

    public static Point ToPoint(this Vector2 value) => new ((int)value.X, (int)value.Y);
}
