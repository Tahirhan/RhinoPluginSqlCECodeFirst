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
        internal class SqlCeDbConfiguration : DbConfiguration
        {
            public SqlCeDbConfiguration()
            {
                SetProviderServices(
                    SqlCeProviderServices.ProviderInvariantName,
                    SqlCeProviderServices.Instance);

                SetDefaultConnectionFactory(
                    new SqlCeConnectionFactory(SqlCeProviderServices.ProviderInvariantName));
            }
        }
    }
}
