namespace RhinoPluginSqlCECodeFirst
{
    using System;
    using System.Data.Entity;
    using System.Data.SqlServerCe;
    using System.Linq;

    [DbConfigurationType(typeof(DbConfig.SqlCeDbConfiguration))]
    public class ModelSqlCECodeFirst : DbContext
    {
        // You can change the path
        static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public ModelSqlCECodeFirst()
            : base(new SqlCeConnection("Data Source=|DataDirectory|" + path + "\\MyDatabase.sdf;Persist Security Info=False;"), contextOwnsConnection: true)
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