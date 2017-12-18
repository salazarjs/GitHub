using Ejercicio.ABC.Data.Interfaces;
using FluentNHibernate.Automapping;
using System;

namespace Ejercicio.ABC.Data.Configurations
{
    public class AutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            var persitentType = typeof(IPersistentModel);
            return persitentType.IsAssignableFrom(type);
        }
    }
}