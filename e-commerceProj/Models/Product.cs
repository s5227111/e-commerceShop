namespace e_commerceProj.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public ICollection<CartProduct> CartProducts { get; set; }
    }
}