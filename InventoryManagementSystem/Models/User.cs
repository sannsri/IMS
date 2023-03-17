using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InventoryManagementSystem.Models
{
    [Table("User", Schema = "inventory")] 
    public partial class User
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(30)]
        [Required]
        public string UserName { get; set; }
        [StringLength(30)]
        [Required]        
        public string Password { get; set; }
        [StringLength(50)]
        public string Role { get; set; }
    }
}
