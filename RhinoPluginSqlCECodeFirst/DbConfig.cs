using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Data.Entity.SqlServerCompact;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhinoPluginSqlCECodeFirst
{
    class DbConfig
    {
        public class SqlCeProviderInvariantName : IProviderInvariantName
        {
            public static readonly SqlCeProviderInvariantName Instance = new SqlCeProviderInvariantName();
            private SqlCeProviderInvariantName() { }
            public const string ProviderName = "System.Data.SqlServerCe.4.0";
            public string Name { get { return ProviderName; } }
        }

        class SqlCeDbProviderFactoryResolver : IDbProviderFactoryResolver
        {
            public static readonly SqlCeDbProviderFactoryResolver Instance = new SqlCeDbProviderFactoryResolver();
            private SqlCeDbProviderFactoryResolver() { }
            public DbProviderFactory ResolveProviderFactory(DbConnection connection)
            {
                if (connection is SqlCeConnection) return SqlCeProviderFactory.Instance;
                if (connection is EntityConnection) return EntityProviderFactory.Instance;
                return null;
            }
        }

        class SqlCeDbDependencyResolver : IDbDependencyResolver
        {
            public object GetService(Type type, object key)
            {
                if (type == typeof(IProviderInvariantName)) return SqlCeProviderInvariantName.Instance;
                if (type == typeof(DbProviderFactory)) return SqlCeProviderFactory.Instance;
                if (type == typeof(IDbProviderFactoryResolver)) return SqlCeDbProviderFactoryResolver.Instance;
                return SqlCeProviderServices.Instance.GetService(type);
            }

            public IEnumerable<object> GetServices(Type type, object key)
            {
                var service = GetService(type, key);
                if (service != null) yield return service;
            }
        }

        internal class SqlCeDbConfiguration : DbConfiguration
        {
            public SqlCeDbConfiguration()
            {
                AddDependencyResolver(new SqlCeDbDependencyResolver());
            }
        }
    }
}
