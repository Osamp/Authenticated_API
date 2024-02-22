// ShoppingCart.cs

using System.Collections.Generic;

namespace ClassLibraryProject
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public string User { get; set; } // Assuming 'User' is a string representing the user's identifier
        public List<Product> Products { get; set; }

        public ShoppingCart()
        {
            Products = new List<Product>();
        }
    }
}
