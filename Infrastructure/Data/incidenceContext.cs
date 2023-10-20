using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Configuration;

namespace Infrastructure.Data;
public class IncidenceContext : DbContext {
    public IncidenceContext(DbContextOptions<IncidenceContext> options) : base(options) { 

    }
        public DbSet<User> ?Users { get; set; }
        public DbSet<TypeIncidence> ? TypeIncedences { get; set; }
        public DbSet<State> ? State { get; set; }
        public DbSet<Rol> ? Rols { get; set; }
        public DbSet<Place> ? Places { get; set; }
        public DbSet<Peripheral> ? Peripherals { get; set; }
        public DbSet<LevelIncidence> ? LevelIncidences { get; set; }
        public DbSet<Incidence> ? Incidence { get; set; }
        public DbSet<DocumentType> ? DocumentTypes { get; set; }
        public DbSet<DetailIncidence> ? DetailIncidences { get; set; }
        public DbSet<ContactType> ? ContactTypes { get; set; }
        public DbSet<Contact> ? Contacts { get; set; }
        public DbSet<CategoryContact> ? CategoryContacts { get; set; }
        public DbSet<AreaUser> ? AreaUsers { get; set; }
        public DbSet<Area> ? Areas { get; set; }
        

       protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new AreaConfiguration());
        modelBuilder.ApplyConfiguration(new AreaUserConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryContactConfiguration());
        modelBuilder.ApplyConfiguration(new ContactConfiguration());
        modelBuilder.ApplyConfiguration(new ContactTypeConfiguration());
        modelBuilder.ApplyConfiguration(new DetailIncidenceConfiguration());
        modelBuilder.ApplyConfiguration(new DocumentTypeConfiguration());
        modelBuilder.ApplyConfiguration(new IncidenceConfiguration());
        modelBuilder.ApplyConfiguration(new LevelIncidenceConfiguration());
        modelBuilder.ApplyConfiguration(new PeripheralConfiguration());
        modelBuilder.ApplyConfiguration(new PlaceConfiguration());
        modelBuilder.ApplyConfiguration(new RolConfiguration());
        modelBuilder.ApplyConfiguration(new StateConfiguration());
        modelBuilder.ApplyConfiguration(new TypeIncidenceConfiguration());





        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}