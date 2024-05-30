// <copyright file="NullElements.cs" company="Sarapulov Vasiliy">
// Copyright (c) Sarapuliv Vasiliy. All rights reserved.
// </copyright>

namespace NullElements
{
    /// <summary>
    /// Class that implements the method of counting zero elements in the list.
    /// </summary>
    public static class NullElements
    {
        /// <summary>
        /// Method for counting the number of null elements in the list.
        /// </summary>
        /// <typeparam name="T">Type of list items.</typeparam>
        /// <param name="list">List of items.</param>
        /// <param name="isNull">The object of checking elements for null.</param>
        /// <returns>Number of null elements.</returns>
        public static int Count<T>(List<T> list, IIsNull isNull)
        {
            if (list is null || isNull is null)
            {
                throw new ArgumentNullException();
            }

            int counter = 0;
            foreach (var item in list)
            {
                if (isNull.IsNull(item))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
