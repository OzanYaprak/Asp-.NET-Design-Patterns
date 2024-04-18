namespace DesignPattern.Iterator.Interfaces
{
    public interface IMover<T>
    {
        IIterator<T> CreateIterator();
    }
}
