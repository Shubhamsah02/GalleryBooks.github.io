using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    public class BooksContext : DbContext
    {
        public DbSet<Admins> Admins { get; set; }

        public DbSet<Books> Books { get; set; }

        public DbSet<Publishers> Publishers { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DatabaseHelper.GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One-To-Many
            modelBuilder.Entity<Books>()
               .HasOne<Publishers>()
               .WithMany()
               .HasForeignKey(d => d.PublisherId);

            //map view to entity
            //modelBuilder.Entity<EmpInfoWithDeptView>().ToView("EmpInfoWithDeptView").HasKey(t => t.EmpCode);

            //add 3 records inside DepartmentMaster table after creating database

            modelBuilder.Entity<Publishers>().HasData(
                new Publishers { PublisherId = 1, PublishersName = "shubham sah", Email = "shubham@gmail.com" },
                new Publishers { PublisherId = 2, PublishersName = "bala", Email = "bala@gmail.com" },
                new Publishers { PublisherId = 3, PublishersName = "krutarth", Email = "krutarth@gmail.com" }
                );


        }
    }
}
