namespace EnvironmentSystem.Interfaces
{
    using System.Collections.Generic;

    using EnvironmentSystem.Models.Objects;

    interface IObjectProducer
    {
        IEnumerable<EnvironmentObject> ProduceObjects();
    }
}
