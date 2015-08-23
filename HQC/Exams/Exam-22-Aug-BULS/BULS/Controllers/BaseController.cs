namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using Exceptions;
    using Interfaces;
    using Models;
    using Utilities;

    public abstract class BaseController
    {
        public User User { get; set; }

        protected IBangaloreUniversityData Data { get; set; }

        public bool HasCurrentUser()
        {
            return this.User != null;
        }

        protected IView View(object model)
        {
            string fullNamespace = this.GetType().Namespace;
            int firstSeparatorIndex = fullNamespace.IndexOf(".");
            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);
            string controllerName = this.GetType().Name.Replace("BaseController", string.Empty);
            string actionName = new StackTrace().GetFrame(1).GetMethod().Name;
            string fullPath = baseNamespace + ".Views." + controllerName + "." + actionName;
            var viewType = Assembly
                .GetExecutingAssembly()
                .GetType(fullPath);
            return Activator.CreateInstance(viewType, model) as IView;
        }

        protected void EnsureAuthorization(params Role[] roles)
        {
            if (!this.HasCurrentUser())
            {
                throw new ArgumentException(Message.NoOneLogged);
            }

            // PERFORMANCE: Redundunt foreach removed, no point in checking
            // same user n times.
            if (!roles.Any(role => this.User.IsInRole(role)))
            {
                throw new AuthorizationFailedException(Message.AuthorizationFailed);
            }
        }
    }
}
