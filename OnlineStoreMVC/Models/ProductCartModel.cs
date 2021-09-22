using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStoreMVC.Models
{
    public class ProductCartModel
    {
        public Product Product { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "This value can't be negative!")] public int Quantity { get; set; }
    }
}