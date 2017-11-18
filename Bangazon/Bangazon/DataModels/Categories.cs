using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bangazon.DataModels
{
    public class Categories
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }

    }
}