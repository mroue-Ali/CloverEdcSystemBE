using System.ComponentModel.DataAnnotations;

namespace CloverEdc.Core.Models;
    public class EntityBase
    {
        
        [Key]
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; } = false;
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public DateTimeOffset? DateDeleted { get; set; }

        protected EntityBase() => Id = Guid.NewGuid();
        
    }
    
