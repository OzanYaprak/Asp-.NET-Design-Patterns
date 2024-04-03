using DesignPattern.Observer.DataAccessLayer;
using DesignPattern.Observer.Models;
using System;

namespace DesignPattern.Observer.ObserverPattern.Classes
{
    public class CreateDiscountCode : IObserver
    {
        #region Constructor

        private readonly IServiceProvider _serviceProvider;
        DbContext _dbContext = new DbContext();

        public CreateDiscountCode(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        #endregion

        public void CreateNewUser(AppUser appUser)
        {
            _dbContext.Discounts.Add(new Discount
            {
                DiscountCode="DERGIMART",
                DiscountAmount = 35,
                DiscountCodeStatus = true,
            });
            _dbContext.SaveChanges();
        }
    }
}
