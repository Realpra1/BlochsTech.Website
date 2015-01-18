using System.Data.Entity;
using Autofac;
using BlochsTech.Website.DataAccess.Infrastructure;
using BlochsTech.Website.Domain.Context;

namespace BlochsTech.Website.Base.Modules
{
    public class DomainModule : Autofac.Module
    {
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DataAccessModule());
            builder.RegisterType(typeof(BlochsTechContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();

        }
    }
}