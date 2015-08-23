namespace BangaloreUniversityLearningSystem.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Basic implementation for data repository.
    /// </summary>
    /// <typeparam name="T">Any type.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Gets all of given T type data.
        /// </summary>
        /// <returns>Enumerable of T elements.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Gets T element by given id.
        /// </summary>
        /// <param name="id">Id number.</param>
        /// <returns>T element.</returns>
        T Get(int id);

        /// <summary>
        /// Adds given T element.
        /// </summary>
        /// <param name="item">Given element.</param>
        void Add(T item);
    }
}