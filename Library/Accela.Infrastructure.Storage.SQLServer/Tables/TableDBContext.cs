namespace Accela.Infrastructure.SQLServer.Table
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TableDBContext : DbContext
    {
        public TableDBContext()
            : base("name=TableDBContext")
        {
            Database.SetInitializer<TableDBContext>(null);
        }

        public TableDBContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer<TableDBContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
