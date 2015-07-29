namespace Theatre.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Allows for manipulation of theatre database.
    /// </summary>
    internal interface IPerformanceDatabase
    {
        /// <summary>
        /// Adds theatre with given name.
        /// </summary>
        /// <param name="theatreName">Name of the theatre.</param>
        void AddTheatre(string theatreName);

        /// <summary>
        /// Returns all theatres.
        /// </summary>
        /// <returns>All theatres</returns>
        IEnumerable<string> ListTheatres();

        /// <summary>
        /// Adds performance with given theatre name, title, starting date and time, duration and price.
        /// </summary>
        /// <param name="theatreName">Performance's theatre.</param>
        /// <param name="performanceTitle">Performance's title.</param>
        /// <param name="startDateTime">Starting date and time.</param>
        /// <param name="duration">Duration of the performance.</param>
        /// <param name="price">Price for the performance.</param>
        void AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price);

        /// <summary>
        /// Returns all performances all theatres.
        /// </summary>
        /// <returns>All performances.</returns>
        IEnumerable<Performance> ListAllPerformances();

        /// <summary>
        /// Returns all performances for given theatre.
        /// </summary>
        /// <param name="theatreName">Theatre name.</param>
        /// <returns></returns>
        IEnumerable<Performance> ListPerformances(string theatreName);
    }
}
