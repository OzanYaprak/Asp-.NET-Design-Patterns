namespace DesignPattern.Iterator.Interfaces
{
    public interface IIterator<T>
    {
        T CurrentItem { get; }
        bool MoveNext();
    }
}
