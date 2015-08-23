namespace BangaloreUniversityLearningSystem.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Controllers;
    using Data;
    using Exceptions;
    using Interfaces;
    using Models;

    public class Engine : IEngine
    {
        public void Run()
        {
            var context = new BangaloreUniversityData();

            User user = null;
            var line = Console.ReadLine();
            while (line != null && line != "end")
            {
                var route = new Router(line);
                var controllerType = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(type => type.Name == route.ControllerName);
                var controller = Activator.CreateInstance(controllerType, context, user) as BaseController;
                var action = controllerType.GetMethod(route.ActionName);
                var parameters = MapParameters(route, action);

                try
                {
                    var view = action.Invoke(controller, parameters) as IView;
                    Console.WriteLine(view.Display());
                    user = controller.User;
                }
                catch (TargetInvocationException ex)
                {
                    if (ex.InnerException is ArgumentException || ex.InnerException is AuthorizationFailedException)
                    {
                        Console.WriteLine(ex.InnerException.Message);
                    }
                    else
                    {
                        throw ex;
                    }
                }

                line = Console.ReadLine();
            }
        }

        private static object[] MapParameters(IRouter router, MethodInfo action)
        {
            return action.GetParameters()
                .Select<ParameterInfo, object>(p =>
                {
                    if (p.ParameterType == typeof(int))
                    {
                        return int.Parse(router.Parameters[p.Name]);
                    }

                    return router.Parameters[p.Name];
                })
                .ToArray();
        }
    }
}
