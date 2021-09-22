using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStoreMVC.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ownerId { get; set; }
        [Required]
        [Display(Name = "Added on")]
        public string AddedOn { get; set; }
        [Required]
        public double Price { get; set; }
        [Required] 
        [Range(0, 100, ErrorMessage = "discount from 0 to 100 is allowed")]
        public int Discount { get; set; }
        [Required]
        public int OrdersNumber { get; set; }
        public virtual ICollection <ImageModel> Images{ get; set; }
        [Required]
        public string Title { get; set; }

        public Product() { }

        public Product(string ownerId, double price, int discount, string title)
        {
            AddedOn = DateTime.Now.ToString();
            OrdersNumber = 0;
            Price = price;
            Discount = discount;
            Title = title;
        }
    }
}