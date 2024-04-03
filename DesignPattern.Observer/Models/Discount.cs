namespace DesignPattern.Observer.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public string DiscountCode { get; set; }
        public int DiscountAmount { get; set; }
        public bool DiscountCodeStatus { get; set; }
    }
}
