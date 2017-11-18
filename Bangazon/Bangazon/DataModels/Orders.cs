using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bangazon.DataModels
{
    public class Orders
    {
        public int Id { get; set; }
        public virtual int UserId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool Paid { get; set; }
        public string DeliveryLocation { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime OrderDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DelivertDate { get; set; }
        [Required]
        public bool Delivery { get; set; }
        public virtual List<Products> Products { get; set; }
    }
}