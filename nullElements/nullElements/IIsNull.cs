// <copyright file="Form1.cs" company="Sarapulov Vasiliy">
// Copyright (c) Sarapuliv Vasiliy. All rights reserved.
// </copyright>

namespace NullElements
{
    /// <summary>
    /// Null Сheck шnterface.
    /// </summary>
    public interface IIsNull
    {
        /// <summary>
        /// A method for checking an element for null.
        /// </summary>
        /// <param name="element">Object to be checked.</param>
        /// <returns>Is the element null.</returns>
        public bool IsNull(object? element);
    }
}