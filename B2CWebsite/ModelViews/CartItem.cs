using B2CWebsite.Models;

namespace B2CWebsite.ModelViews
{
    public class CartItem
    {
        public Supplement supplement { get; set; }
        public int amount{ get; set;}
        public double TotalMoney => amount * supplement.Price.Value;
    }
}
