using System.Security.Cryptography;
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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
//asdasdasd
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
            
            modelBuilder.Entity<CrfFile>()
            .HasMany(e => e.SubFiles)
            .WithOne()
            .HasForeignKey(e => e.ParentFileId)
            .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<BaseField>()
                .HasMany(b => b.DropDownOptions)
                .WithOne(d => d.BaseField)
                .HasForeignKey(d => d.BaseFieldId);
            
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
            //what is decimal in .Net Core
            //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types
            var superAdminGuid = Guid.NewGuid();
           modelBuilder.Entity<Type>().HasData(
                new Type { Id = Guid.NewGuid(), Name = "Text",DataType = "string" },
                new Type { Id = Guid.NewGuid(), Name = "Number" ,DataType = "decimal"},
                new Type { Id = Guid.NewGuid(), Name = "Date" ,DataType = "DateTime"},
                new Type { Id = Guid.NewGuid(), Name = "DropDown" , DataType = "List<string>"},
                new Type { Id = Guid.NewGuid(), Name = "File" , DataType = "File"},
                new Type { Id = Guid.NewGuid(), Name = "ToggleButton" , DataType = "bool"}  
            );
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = Guid.NewGuid(), Name = "Admin" },
                new Role { Id = superAdminGuid, Name = "SuperAdmin" },
                new Role { Id = Guid.NewGuid(), Name = "PI" },
                new Role { Id = Guid.NewGuid(), Name = "CRC" },
                new Role { Id = Guid.NewGuid(), Name = "DM" }
            );
            modelBuilder.Entity<Protocol>().HasData(
                new Protocol { Id = Guid.NewGuid(), Name = "Protocol-1", NumOfVisits = 3, Randomization = true },
                new Protocol { Id = Guid.NewGuid(), Name = "Protocol-2", NumOfVisits = 2, Randomization = false }
            );
            var hashedPassword = CreatePasswordHash("sa");

            modelBuilder.Entity<User>().HasData(
                new User("superAdmina", "Supera", "Admina", "superAdmin@example.com", hashedPassword,
                    superAdminGuid)
            );
        }

        public string CreatePasswordHash(string password)
        {
            // Generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Generate a 256-bit hash using PBKDF2 with 100,000 iterations
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(32); // 32-byte hash

                // Combine salt and hash as a single byte array
                byte[] hashBytes = new byte[48]; // 16 bytes for salt + 32 bytes for hash
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 32);

                // Convert to base64 for storage
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}