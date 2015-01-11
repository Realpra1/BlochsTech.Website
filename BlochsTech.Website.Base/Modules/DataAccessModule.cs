using System.Reflection;
using Autofac;

namespace BlochsTech.Website.Base.Modules
{
    public class DataAccessModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("BlochsTech.Website.DataAccess"))
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }

    }
}