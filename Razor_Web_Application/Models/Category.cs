using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Razor_Web_Application.Models
{
    public class Category
    {
            [Key]
            public int Id { get; set; }
            [Required] //these means that Name is required(must which is not null
            [MaxLength(30)] /////////max 30 character
            [DisplayName("Category Name")]
            public string Name { get; set; }
            [DisplayName("Display Order")] //this data annotation which help with client side validation
            [Range(1, 100, ErrorMessage = "Display order must be between 1-100")] /////////Here are adding validation min 1, max 100
            public int DisplayOrders { get; set; }

    }
}
