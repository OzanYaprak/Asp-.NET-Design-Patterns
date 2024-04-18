using DesignPattern.Facade.Data;
using DesignPattern.Facade.Models;

namespace DesignPattern.Facade.FacadePattern
{
    public class AddOrder
    {
        Context context = new Context();

        public void AddNewOrder(Order order)
        {
            order.OrderDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.Orders.Add(order);
            context.SaveChanges();
        }
    }
}
