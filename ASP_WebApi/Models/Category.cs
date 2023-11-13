using System.ComponentModel.DataAnnotations;

namespace ASP_WebApi.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; } 
        [Required] //these means that Name is required(must which is not null) 
        public string Name { get; set; }
        public  int   DisplayOrders { get; set; }

    }
}
