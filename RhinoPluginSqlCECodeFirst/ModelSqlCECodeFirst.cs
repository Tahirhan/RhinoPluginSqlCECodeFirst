namespace RhinoPluginSqlCECodeFirst
{
    using System;
    using System.Data.Entity;
    using System.Data.SqlServerCe;
    using System.Linq;

    [DbConfigurationType(typeof(DbConfig.SqlCeDbConfiguration))]
    public class ModelSqlCECodeFirst : DbContext
    {
        // Your context has been configured to use a 'ModelSqlCECodeFirst' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'RhinoPluginSqlCECodeFirst.ModelSqlCECodeFirst' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ModelSqlCECodeFirst' 
        // connection string in the application configuration file.
        public ModelSqlCECodeFirst()
            : base(new SqlCeConnection("Data Source=|DataDirectory|MyDatabase.sdf;Persist Security Info=False;"), contextOwnsConnection: true)
        {
            Database.SetInitializer<ModelSqlCECodeFirst>(new CreateDatabaseIfNotExists<ModelSqlCECodeFirst>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    public class MyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}