using Microsoft.EntityFrameworkCore;
using Intranet.Models;

namespace Intranet.DBContexts
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }
        public DbSet<Student> Students{ get; set; }
        public DbSet<Major> Majors{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Major>(entity =>
            {
                entity.HasKey(m => m.ID);
                entity.Property(entity => entity.Name).IsRequired();

            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasOne(s => s.StudentMajor).WithMany(p => p.Students).HasForeignKey(s => s.MajorId).OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
