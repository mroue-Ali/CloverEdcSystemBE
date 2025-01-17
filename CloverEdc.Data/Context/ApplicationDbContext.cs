using CloverEdc.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using File = CloverEdc.Core.Models.File;
using Type = CloverEdc.Core.Models.Type;

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
        public DbSet<File> Files { get; set; }
        public DbSet<CrfField> CrfFields { get; set; }
        public DbSet<CrfValue> CrfValues { get; set; }
        public DbSet<DropDownOption> DropDownOptions { get; set; }

        // Supporting Entities
        public DbSet<AuditTrail> AuditTrails { get; set; }
        public DbSet<AdverseEvent> AdverseEvents { get; set; }
        public DbSet<Query> Queries { get; set; }
        public DbSet<Lock> Locks { get; set; }

        // Many-to-Many Relationship Tables
        public DbSet<BaseField> BaseFields { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<DmQuery> DmQueries { get; set; }
        public DbSet<CrcCrf> CrcCrfs { get; set; }

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
            modelBuilder.Entity<CrcCrf>()
                .HasKey(cc => new { cc.CrcId, cc.CrfId });

            modelBuilder.Entity<CrcCrf>()
                .HasOne(cc => cc.Crc)
                .WithMany(c => c.CrcCrfs)
                .HasForeignKey(cc => cc.CrcId);

            modelBuilder.Entity<CrcCrf>()
                .HasOne(cc => cc.Crf)
                .WithMany(c => c.CrcCrfs)
                .HasForeignKey(cc => cc.CrfId);

            // Repeat similar configurations for DmQuery
            modelBuilder.Entity<DmQuery>()
                .HasKey(dq => new { dq.DmId, dq.QueryId });

            modelBuilder.Entity<DmQuery>()
                .HasOne(dq => dq.Dm)
                .WithMany(d => d.DmQueries)
                .HasForeignKey(dq => dq.DmId);

            modelBuilder.Entity<DmQuery>()
                .HasOne(dq => dq.Query)
                .WithMany(q => q.DmQueries)
                .HasForeignKey(dq => dq.QueryId);
            
            // modelBuilder.Entity<Dm>()
            //     .HasMany(c => c.DmQueries)
            //     .WithOne(cs => cs.Dm)
            //     .HasForeignKey(cs => cs.DmId);
            //
            // modelBuilder.Entity<DmQuery>()
            //     .HasOne(cs => cs.Dm)
            //     .WithMany()
            //     .HasForeignKey(cs => cs.DmId);
            //
            //   modelBuilder.Entity<Query>()
            //     .HasMany(c => c.DmQueries)
            //     .WithOne(cs => cs.Query)
            //     .HasForeignKey(cs => cs.QueryId);
            //
            // modelBuilder.Entity<DmQuery>()
            //     .HasOne(cs => cs.Query)
            //     .WithMany()
            //     .HasForeignKey(cs => cs.QueryId);
            //
            // modelBuilder.Entity<Crc>()
            //     .HasMany(c => c.CrcCrfs)
            //     .WithOne(cs => cs.Crc)
            //     .HasForeignKey(cs => cs.CrcId);
            //
            // modelBuilder.Entity<CrcCrf>()
            //     .HasOne(cs => cs.Crc)
            //     .WithMany()
            //     .HasForeignKey(cs => cs.CrcId);
            //    modelBuilder.Entity<Crf>()
            //     .HasMany(c => c.CrcCrfs)
            //     .WithOne(cs => cs.Crf)
            //     .HasForeignKey(cs => cs.CrfId);
            //
            // modelBuilder.Entity<CrcCrf>()
            //     .HasOne(cs => cs.Crf)
            //     .WithMany()
            //     .HasForeignKey(cs => cs.CrfId);
            //
            
            
            // Seed initial data
            var adminGuid = "f45a7e79-845f-47df-af36-dc486e563772";
            var superAdminGuid = "f567a244-752e-41c0-9af7-7bd85c71cf41";
            modelBuilder.Entity<Role>().HasData(
                new Role { Id=Guid.Parse(adminGuid), Name = "Admin" },
                new Role { Id = Guid.Parse(superAdminGuid), Name = "SuperAdmin" }
            );
            var hashedPassword = new PasswordHasher<User>().HashPassword(null, "sa");
            modelBuilder.Entity<User>().HasData(
                new User("superAdmin", "Super","Admin","superAdmin@example.com", hashedPassword, Guid.Parse(superAdminGuid))
            );
        }
        
    }
   
}