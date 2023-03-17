using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InventoryManagementSystem.Models
{
    [Table("Order", Schema = "inventory")]
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [InverseProperty(nameof(OrderProduct.Order))]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
