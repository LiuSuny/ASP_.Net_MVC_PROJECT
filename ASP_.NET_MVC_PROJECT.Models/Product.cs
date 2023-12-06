using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ASP_.Net_MVC_PROJECT.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required] //these means that Name is required(must which is not null
        public string Title { get; set; }
       
        [Required]
        public string Description{ get; set; }
        [Required] 
        public string ISBN { get; set; }
        [Required] 
        public string Author { get; set; }
        [Required] 
        [Display(Name = "List Price")] //To allow space within our text using anotation
        [Range (1, 1000)] //Validation to let our customer know that price is within 1-1000 dollar
        public double ListPrice { get; set; }
       
        [Required]
        [Display(Name = "Price for 1-50")] 
        [Range(1, 1000)] 
        public double Price { get; set; }

        [Required]
        [Display(Name = "Price for 50+")]
        [Range(1, 1000)]
        public double Price50 { get; set; }

        [Required]
        [Display(Name = "Price for 100+")]
        [Range(1, 1000)]
        public double Price100 { get; set; }

        public int CategoryId { get; set; } //just only these table would not know it a foreign
        [ForeignKey("CategoryId")] //these tell our program that CategoryId is a foregn key
        [ValidateNever]
        public Category Category { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
