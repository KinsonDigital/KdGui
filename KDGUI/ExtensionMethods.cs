// <copyright file="ExtensionMethods.cs" company="KinsonDigital">
// Copyright (c) KinsonDigital. All rights reserved.
// </copyright>

namespace KdGui;

using System.Diagnostics.CodeAnalysis;
using SimpleInjector;
using SimpleInjector.Diagnostics;

/// <summary>
/// Provides utility methods for the application.
/// </summary>
internal static class ExtensionMethods
{
    /// <summary>
    /// Registers that a new instance of <typeparamref name="TImplementation"/> will be returned every time
    /// a <typeparamref name="TService"/> is requested (transient).
    /// </summary>
    /// <typeparam name="TService">The interface or base type that can be used to retrieve the instances.</typeparam>
    /// <typeparam name="TImplementation">The concrete type that will be registered.</typeparam>
    /// <param name="container">The container that the registration applies to.</param>
    /// <param name="lifeStyle">The lifestyle that specifies how the returned instance will be cached.</param>
    /// <param name="suppressDisposal"><c>true</c> to ignore dispose warnings if the original code invokes dispose.</param>
    /// <remarks>
    ///     This method uses the container's LifestyleSelectionBehavior to select the exact
    ///     lifestyle for the specified type. By default this will be Transient.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when one of the arguments is a null reference.</exception>
    /// <exception cref="InvalidOperationException">Thrown when this container instance is locked and cannot be altered.</exception>
    [ExcludeFromCodeCoverage(Justification = $"Cannot test due to interaction with 'IoC' container.")]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = "Left here for future development.")]
    public static void Register<TService, TImplementation>(this Container container, Lifestyle lifeStyle, bool suppressDisposal = false)
        where TService : class
        where TImplementation : class, TService
    {
        container.Register<TService, TImplementation>(lifeStyle);

        if (suppressDisposal)
        {
            SuppressDisposableTransientWarning<TService>(container);
        }
    }

    /// <summary>
    /// Suppresses SimpleInjector diagnostic warnings related to disposing of objects when they
    /// inherit from <see cref="IDisposable"/>.
    /// </summary>
    /// <typeparam name="T">The type to suppress against.</typeparam>
    /// <param name="container">The container that the suppression applies to.</param>
    [ExcludeFromCodeCoverage(Justification = $"Cannot test due to interaction with 'IoC' container.")]
    private static void SuppressDisposableTransientWarning<T>(this Container container)
    {
        var registration = container.GetRegistration(typeof(T))?.Registration;
        registration?.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, "Disposing of objects to be disposed of manually by the library.");
    }
}
