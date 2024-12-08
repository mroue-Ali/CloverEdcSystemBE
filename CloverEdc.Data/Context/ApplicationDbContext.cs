using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CloverEdc.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        
        // Crc and Dm
        public DbSet<Crc> Crcs { get; set; }
        public DbSet<Dm> Dms { get; set; }
        public DbSet<Pi> Pis { get; set; }
        
        // Sites, Studies, and Protocols
        public DbSet<Site> Sites { get; set; }
        public DbSet<Study> Studies { get; set; }
        public DbSet<Protocol> Protocols { get; set; }

        // Patients and CRFs
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Crf> Crfs { get; set; }
        public DbSet<CrfTemplate> CrfTemplates { get; set; }
        public DbSet<CrfFile> CrfFiles { get; set; }
        public DbSet<CrfPage> CrfPages { get; set; }
        public DbSet<CrfField> CrfFields { get; set; }
        public DbSet<CrfValue> CrfValues { get; set; }

        // Supporting Entities
        public DbSet<AuditTrail> AuditTrails { get; set; }
        public DbSet<AdverseEvent> AdverseEvents { get; set; }
        public DbSet<Query> Queries { get; set; }
        public DbSet<Lock> Locks { get; set; }

        // Many-to-Many Relationship Tables
        public DbSet<CrcSite> CrcSites { get; set; }
        public DbSet<DmSite> DmSites { get; set; }
        public DbSet<PiSite> PiSites { get; set; }

        // Requests
        public DbSet<UpdateRequest> UpdateRequests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // // Define relationships
            // modelBuilder.Entity<User>()
            //     .HasOne(u => u.Role)
            //     .WithMany()
            //     .HasForeignKey(u => u.RoleId);
            modelBuilder.Entity<Crc>()
                .HasMany(c => c.CrcSites)
                .WithOne(cs => cs.Crc)
                .HasForeignKey(cs => cs.CrcId);

            modelBuilder.Entity<CrcSite>()
                .HasOne(cs => cs.Site)
                .WithMany()
                .HasForeignKey(cs => cs.SiteId);
            
            modelBuilder.Entity<Pi>()
                .HasMany(c => c.PiSites)
                .WithOne(cs => cs.Pi)
                .HasForeignKey(cs => cs.PiId);

            modelBuilder.Entity<PiSite>()
                .HasOne(cs => cs.Site)
                .WithMany()
                .HasForeignKey(cs => cs.SiteId);
            
            
            // Seed initial data
            var adminGuid = "f45a7e79-845f-47df-af36-dc486e563772";
            var superAdminGuid = "f567a244-752e-41c0-9af7-7bd85c71cf41";
            modelBuilder.Entity<Role>().HasData(
                new Role { Id=Guid.Parse(adminGuid), Name = "Admin" },
                new Role { Id = Guid.Parse(superAdminGuid), Name = "SuperAdmin" }
            );
            var hashedPassword = new PasswordHasher<User>().HashPassword(null, "password");
            modelBuilder.Entity<User>().HasData(
                new User("admin", "A","Admin","admin@example.com", hashedPassword,Guid.Parse(adminGuid)),
                new User("superAdmin", "Super","Admin","superAdmin@example.com", hashedPassword, Guid.Parse(superAdminGuid))
            );
        }
        
    }
   
}