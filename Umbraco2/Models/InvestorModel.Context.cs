﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Umbraco2.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Umbraco2Entities : DbContext
    {
        public Umbraco2Entities()
            : base("name=Umbraco2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<z_InvestedHistory> z_InvestedHistory { get; set; }
        public virtual DbSet<z_InvestorProject> z_InvestorProject { get; set; }
        public virtual DbSet<z_Person> z_Person { get; set; }
        public virtual DbSet<z_SolarPanelInfo> z_SolarPanelInfo { get; set; }
        public virtual DbSet<umbracoUser> umbracoUsers { get; set; }
        public virtual DbSet<z_investeraDashboardPermission> z_investeraDashboardPermission { get; set; }
    }
}
