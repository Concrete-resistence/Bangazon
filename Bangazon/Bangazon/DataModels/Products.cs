using Bangazon.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bangazon.DataModels
{
    public class Products
    {
        
        public int Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductLocation { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        public virtual int CategoryId { get; set; }
        [Required]
        public virtual int TypeId { get; set; }
        public virtual List<Orders> Orders { get; set; }
    }
}