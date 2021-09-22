using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineStoreMVC.Models
{
    public abstract class Filter
    {
        public abstract List<Product> filter(IEnumerable<Product> products);
    }
    public class FilterPrice : Filter
    {
        public int min { get; set; }
        public int? max { get; set; }

        public override List<Product> filter(IEnumerable<Product> products)
        {
            if(max != null)
                return products.Where(product => product.Price * (1 - (double)product.Discount / 100) >= min && product.Price * (1 - (double)product.Discount / 100) <= max).ToList();  
            return products.Where(product => product.Price * (1 - (double)product.Discount / 100) >= min).ToList();
        }
    }
}