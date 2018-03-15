namespace FolderHierarchy.Core.DataContexts
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using FolderHierarchy.Core.Entities;

    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
        }

        public virtual DbSet<Folder> Folders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Folder>()
                .HasMany(e => e.FolderChilds)
                .WithOptional(e => e.Parent)
                .HasForeignKey(e => e.ParentId);
        }
    }
}
