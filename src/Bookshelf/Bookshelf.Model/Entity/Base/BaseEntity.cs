using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookshelf.Model.Entity.Base
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            CreationDate = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ModificationDate { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime? DeletedAt { get; set; }
    }
}
