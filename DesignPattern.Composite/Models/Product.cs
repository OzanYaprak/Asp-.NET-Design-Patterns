namespace DesignPattern.Composite.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        #region Reference

        public Category Category { get; set; }
        public int CategoryId { get; set; }
        
        #endregion
    }
}
