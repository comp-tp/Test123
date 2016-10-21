﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Accela.Infrastructure.Storage.SQLServer.Binary
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SQLServerBinaryStorageEntities : DbContext
    {
        public SQLServerBinaryStorageEntities()
            : base("name=SQLServerBinaryStorageEntities")
        {
            Database.SetInitializer<SQLServerBinaryStorageEntities>(null);
        }

        public SQLServerBinaryStorageEntities(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer<SQLServerBinaryStorageEntities>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BlobContainer> BlobContainers { get; set; }
        public virtual DbSet<BlobItem> BlobItems { get; set; }
    }
}