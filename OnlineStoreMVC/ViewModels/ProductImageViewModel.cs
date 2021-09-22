using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStoreMVC.Models
{
    public class ProductImageViewModel
    {
        [Required]
        public double Price { get; set; }
        [Required]
        [Range(0, 100, ErrorMessage = "discount from 0 to 100 is allowed")]
        public int Discount { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Image links")]
        public string ImgSources { get; set; }
        [Required]
        public string Title { get; set; }
    }
}