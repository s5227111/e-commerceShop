namespace e_commerceProj.Models
{
    public class CartProduct
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }




        public int ProductID { get; set; }
        public Product Product { get; set; }




        public int CartID { get; set; }
        public Cart Cart { get; set; }
    }
}