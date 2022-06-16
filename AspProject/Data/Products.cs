using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AspProject.Data
{
    public class Products
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(100)]
      
        public string ProductName { get; set; }

        public double Price { get; set; }


        public int Quantity { get; set; }

        [MaxLength(50)]
        public string Category { get; set; }

      
     
     //   public IFormFile Image { get; set; }

    }
}
