using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InventoryManagementSystem.Models
{
    [Table("OrderProducts", Schema = "inventory")]
    public partial class OrderProduct
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderProducts")]
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("OrderProducts")]
        public virtual Product Product { get; set; }
    }
}
