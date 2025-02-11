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

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AcceptorDetail> AcceptorDetails { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<BloodGroup> BloodGroups { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<CityArea> CityAreas { get; set; }
        public virtual DbSet<ColonyArea> ColonyAreas { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Donar> Donars { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<MartialStatu> MartialStatus { get; set; }
        public virtual DbSet<Relationship> Relationships { get; set; }
        public virtual DbSet<CityAreaView> CityAreaViews { get; set; }
        public virtual DbSet<CityView> CityViews { get; set; }
        public virtual DbSet<ColonyAreaView> ColonyAreaViews { get; set; }
        public virtual DbSet<DonarDetailView> DonarDetailViews { get; set; }
        public virtual DbSet<DonarRelationshipView> DonarRelationshipViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

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
                .HasMany(e => e.AcceptorDetails)
                .WithRequired(e => e.Donar)
                .HasForeignKey(e => e.DonatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Donar>()
                .HasMany(e => e.AcceptorDetails1)
                .WithRequired(e => e.Donar1)
                .HasForeignKey(e => e.DonatedTo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Donar>()
                .HasMany(e => e.Donars1)
                .WithMany(e => e.Donars)
                .Map(m => m.ToTable("DonarRelationships").MapLeftKey("PersonId").MapRightKey("RelatedPersonId"));

            modelBuilder.Entity<MartialStatu>()
                .HasMany(e => e.Donars)
                .WithOptional(e => e.MartialStatu)
                .HasForeignKey(e => e.MartialStatusId);

            modelBuilder.Entity<CityAreaView>()
                .Property(e => e.CityAreaName)
                .IsUnicode(false);

            modelBuilder.Entity<ColonyAreaView>()
                .Property(e => e.CityAreaName)
                .IsUnicode(false);

            modelBuilder.Entity<DonarDetailView>()
                .Property(e => e.Age)
                .HasPrecision(18, 1);
        }
    }
}
