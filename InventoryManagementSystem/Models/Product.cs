using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InventoryManagementSystem.Models
{
    [Table("Product", Schema = "inventory")]
    public partial class Product
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public int ProductCode { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }
        public int MinQuantity { get; set; }
        public int Quantity { get; set; }
        public bool? IsSuccess { get; set; }

        [InverseProperty(nameof(OrderProduct.Product))]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
