namespace DataService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Advertisment")]
    public partial class Advertisment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        public int SlotId { get; set; }

        public int DurationMinute { get; set; }

        public double Price { get; set; }

        public bool IsEnable { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? LastModifiedTime { get; set; }
    }
}
