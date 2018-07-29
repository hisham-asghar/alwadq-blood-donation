namespace LayerDb
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DbModelStr")
        {
        }

        public virtual DbSet<AcceptorDetail> AcceptorDetails { get; set; }
        public virtual DbSet<BloodGroup> BloodGroups { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<CityArea> CityAreas { get; set; }
        public virtual DbSet<ColonyArea> ColonyAreas { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Donar> Donars { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<MartialStatu> MartialStatus { get; set; }
        public virtual DbSet<Relationship> Relationships { get; set; }
        public virtual DbSet<DonarRelationship> DonarRelationships { get; set; }
        public virtual DbSet<CityAreaView> CityAreaViews { get; set; }
        public virtual DbSet<CityView> CityViews { get; set; }
        public virtual DbSet<ColonyAreaView> ColonyAreaViews { get; set; }
        public virtual DbSet<DonarDetailView> DonarDetailViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BloodGroup>()
                .HasMany(e => e.Donars)
                .WithRequired(e => e.BloodGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.CityAreas)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CityArea>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<CityArea>()
                .HasMany(e => e.ColonyAreas)
                .WithRequired(e => e.CityArea)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ColonyArea>()
                .HasMany(e => e.Donars)
                .WithRequired(e => e.ColonyArea)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Cities)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Donar>()
                .HasMany(e => e.DonarRelationships)
                .WithRequired(e => e.Donar)
                .HasForeignKey(e => e.PersonId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Donar>()
                .HasMany(e => e.DonarRelationships1)
                .WithRequired(e => e.Donar1)
                .HasForeignKey(e => e.RelatedPersonId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MartialStatu>()
                .HasMany(e => e.Donars)
                .WithOptional(e => e.MartialStatu)
                .HasForeignKey(e => e.MartialStatusId);

            modelBuilder.Entity<Relationship>()
                .HasMany(e => e.DonarRelationships)
                .WithRequired(e => e.Relationship)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CityAreaView>()
                .Property(e => e.CityAreaName)
                .IsUnicode(false);

            modelBuilder.Entity<ColonyAreaView>()
                .Property(e => e.CityAreaName)
                .IsUnicode(false);
        }
    }
}
