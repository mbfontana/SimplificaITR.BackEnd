using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using SimplificaITR.BackEnd.Models;
using Property = SimplificaITR.BackEnd.Models.Property;

namespace SimplificaITR.BackEnd.Data
{
    public class SimplificaITRContext : DbContext
    {
        public SimplificaITRContext(DbContextOptions<SimplificaITRContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cliente>()
                .HasOne(cliente => cliente.User)
                .WithMany(user => user.Clientes)
                .HasForeignKey(cliente => cliente.UserId);

            builder.Entity<Property>()
                .HasOne(property => property.Cliente)
                .WithMany(cliente => cliente.Properties)
                .HasForeignKey(property => property.ClienteId);

            builder.Entity<Property>()
                .HasOne(property => property.City)
                .WithMany(city => city.Properties)
                .HasForeignKey(property => property.CityId);

            builder.Entity<Area>()
                .HasOne(area => area.Property)
                .WithMany(property => property.Areas)
                .HasForeignKey(area => area.PropertyId);

            builder.Entity<Area>()
                   .HasOne(area => area.Condition)
                   .WithMany(condition => condition.Areas)
                   .HasForeignKey(area => area.ConditionId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Condition> Conditions { get; set; }
    }
}
