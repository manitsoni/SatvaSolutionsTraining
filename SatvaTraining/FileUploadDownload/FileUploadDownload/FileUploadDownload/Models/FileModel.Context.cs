﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FileUploadDownload.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FileUploadDownloadEntities : DbContext
    {
        public FileUploadDownloadEntities()
            : base("name=FileUploadDownloadEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tblFile> tblFiles { get; set; }
        public virtual DbSet<tblFileDownload> tblFileDownloads { get; set; }
        public virtual DbSet<tblRegister> tblRegisters { get; set; }
    }
}