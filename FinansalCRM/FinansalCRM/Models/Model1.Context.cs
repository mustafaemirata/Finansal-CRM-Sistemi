﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinansalCRM.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbFinansalCRMEntities : DbContext
    {
        public DbFinansalCRMEntities()
            : base("name=DbFinansalCRMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BankProcess> BankProcess { get; set; }
        public virtual DbSet<Banks> Banks { get; set; }
        public virtual DbSet<Bills> Bills { get; set; }
        public virtual DbSet<Spendings> Spendings { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tbl_Categories> Tbl_Categories { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
