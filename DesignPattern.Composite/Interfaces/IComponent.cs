namespace DesignPattern.Composite.Interfaces
{
    public interface IComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }

        int TotalCount();
        string Display();
    }
}
