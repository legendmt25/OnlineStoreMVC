using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStoreMVC.Models
{
    public class ListProductsWithFilterModel
    {
        public string submit { get; set; }
        public FilterPrice filterByPrice { get; set; }
        public List<Product> products { get; set; }
    }
}