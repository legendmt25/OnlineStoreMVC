using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStoreMVC.Models
{
    public class Order
    {
        public static List<Product> orderByPrice(IEnumerable<Product> products, bool ascending = false)
        {
            if(!ascending)
                return products.OrderByDescending(product => product.Price).ToList();
            return products.OrderBy(product => product.Price).ToList();
        }
        public static List<Product> orderByOrders(IEnumerable<Product> products, bool ascending = false)
        {
            if (!ascending)
                return products.OrderByDescending(product => product.OrdersNumber).ToList();
            return products.OrderBy(product => product.OrdersNumber).ToList();
        }
        public static List<Product> orderByDate(IEnumerable<Product> products, bool ascending = false)
        {
            if (!ascending)
                return products.OrderByDescending(product => DateTime.Parse(product.AddedOn)).ToList();
            return products.OrderBy(product => DateTime.Parse(product.AddedOn)).ToList();
        }
    }
}