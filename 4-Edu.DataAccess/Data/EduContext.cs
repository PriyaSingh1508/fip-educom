using Edu.DAL.Entities;
using Edu.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Edu.DAL.Data
{
    public class EduContext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Technology>().HasMany(c => c.TutorialCategory).WithOne(a => a.Technology).HasForeignKey(a => a.TechnologyId);
            modelBuilder.Entity<TutorialCategory>().HasMany(c => c.TutorialItems).WithOne(a => a.TutorialCategory).HasForeignKey(a => a.TutorialCategoryId);
            modelBuilder.Entity<AdminModel>().HasData(
                //password=admin@1234
                new AdminModel { Id=1,Email="admin@gmail.com",Password= "SEEp98ny9hiFD6hTLev66ay8n/+000zDOtjWa2qESTDh3gnH"}
                );
            modelBuilder.Entity<User>().HasData(
                //password=admin@1234
                new User { Id = 1, Email = "admin@gmail.com", Password = "SEEp98ny9hiFD6hTLev66ay8n/+000zDOtjWa2qESTDh3gnH",UserRole="Admin" }
                );
        }
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Address>Addresses { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<City>Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet <Country> Countries { get; set;}
        public DbSet<StudentEntity> Student { get; set; }
      
        public DbSet<AdminModel> Admins { get; set; }

        public DbSet<Technology> Technologies { get; set; }
       
        public DbSet<TutorialCategory> TutorialCategories { get; set; }

       public DbSet<TutorialItem>TutorialItems { get; set; }

        public EduContext(DbContextOptions<EduContext> options)
            : base(options)
        { }
       
    }
}
