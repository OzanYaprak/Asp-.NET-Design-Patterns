using DesignPattern.Iterator.Interfaces;
using DesignPattern.Iterator.Models;
using DesignPattern.Iterator.Movers;

namespace DesignPattern.Iterator.Iterators
{
    public class VisitRouteIterator : IIterator<VisitRoute>
    {
        private VisitRouteMover _mover;

        public VisitRouteIterator(VisitRouteMover mover)
        {
            _mover = mover;
        }
        private int currentIndex = 0;
       
        public VisitRoute CurrentItem {  get; set; }

        public bool MoveNext()
        {
            if (currentIndex < _mover.VisitRouteCounts)
            {
                CurrentItem = _mover.VisitRoutes[currentIndex++];
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
