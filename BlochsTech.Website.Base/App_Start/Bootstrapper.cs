using System.Data.Entity;
using System.Reflection;
using Autofac;
using BlochsTech.Website.DataAccess.Infrastructure;

namespace BlochsTech.Website.Base
{
    public static class Bootstrapper 
    {
        public static void Run()
        {
            SetAutofacContainer();
        }
        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();

        }
    }
}