namespace DataService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(200)]
        public string PasswordHash { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? LastModifiedTime { get; set; }

        public int RoleId { get; set; }

        [Required]
        [StringLength(50)]
        public string Fullname { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? LastLoginTime { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        public virtual Role Role { get; set; }
    }
}
