namespace Accela.Infrastructure.SQLServer.Queue
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QueueDBContext : DbContext
    {
        public QueueDBContext()
            : base("name=QueueDBContext")
        {
            Database.SetInitializer<QueueDBContext>(null);
        }

        public QueueDBContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer<QueueDBContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
