using System;
using MCN.Core.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata; 

namespace MCN.ServiceRep.BAL.ContextModel
{
 
    public class RepositoryContext : DbContext
    {
        public RepositoryContext()
        {
        }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAuthtoken> UserAuthtoken { get; set; }
        public virtual DbSet<UserMultiFactor> UserMultiFactors { get; set; }
        public virtual DbSet<UserLoginType> UserLoginType { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=VicinityDb;Integrated Security=true;");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Composite Primary Key for UserInterests
            //builder.Entity<UserInterest>().HasKey(table => new { table.UserId, table.InterestId });
        } 
    }

}
