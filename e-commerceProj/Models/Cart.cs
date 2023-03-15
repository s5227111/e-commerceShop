using System.ComponentModel.DataAnnotations;
namespace e_commerceProj.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public decimal Total { get; set; }
        public decimal CodeDiscount { get; set; }
        public List<CartProduct> CartProducts { get; set; }

    }
}