using DesignPattern.Iterator.Interfaces;
using DesignPattern.Iterator.Iterators;
using DesignPattern.Iterator.Models;

namespace DesignPattern.Iterator.Movers
{
    public class VisitRouteMover : IMover<VisitRoute>
    {
        public List<VisitRoute> VisitRoutes = new List<VisitRoute>();


        public void AddVisitRoute(VisitRoute visitRoute)
        {
            VisitRoutes.Add(visitRoute);
        }

        public int VisitRouteCounts { get => VisitRoutes.Count; }

        public IIterator<VisitRoute> CreateIterator()
        {
            return new VisitRouteIterator(this);
        }
    }
}
