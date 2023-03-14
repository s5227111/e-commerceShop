namespace e_commerceProj.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }


        public ICollection<CartProduct> CartProducts { get; set; }
    }
}