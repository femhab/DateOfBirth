using DateOfBirthApp.Data.Entity;
using DateOfBirthApp.Data.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DateOfBirthApp.Data.AppContext
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.EnableAutoHistory(null);
            //this converts all enums to string equivalence
            modelBuilder.Entity<User>().Property(e => e.Title).HasMaxLength(30).HasConversion(new EnumToStringConverter<Title>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
