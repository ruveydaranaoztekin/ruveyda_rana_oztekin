using Microsoft.EntityFrameworkCore;

namespace WebAppCoreMVCCodeFirst._24._03._2023_22.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlite("Data Source=okul.db");
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}