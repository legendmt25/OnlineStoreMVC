using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStoreMVC.Models
{
    public class ImageModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required]
        public string ImageSrc { get; set; }
    }
}