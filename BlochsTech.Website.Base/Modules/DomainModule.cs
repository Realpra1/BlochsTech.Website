using System.Data.Entity;
using Autofac;
using BlochsTech.Website.DataAccess.Infrastructure;
using BlochsTech.Website.Domain.Context;

namespace BlochsTech.Website.Base.Modules
{
    public class DomainModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DataAccessModule());
            builder.RegisterType(typeof (BlochsTechContext)).As(typeof (DbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof (UnitOfWork)).As(typeof (IUnitOfWork)).InstancePerRequest();

        }
    }
}