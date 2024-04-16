namespace DesignPattern.Composite.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int UpperCategoryId { get; set; }

        #region Reference

        public List<Product> Products { get; set; }

        #endregion
    }
}
