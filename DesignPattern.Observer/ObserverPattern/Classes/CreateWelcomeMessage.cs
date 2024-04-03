using DesignPattern.Observer.DataAccessLayer;
using DesignPattern.Observer.Models;
using System;

namespace DesignPattern.Observer.ObserverPattern.Classes
{
    public class CreateWelcomeMessage : IObserver
    {
        #region Constructor

        private readonly IServiceProvider _serviceProvider;
        DbContext _dbContext = new DbContext();

        public CreateWelcomeMessage(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        #endregion

        public void CreateNewUser(AppUser appUser)
        {
            _dbContext.WelcomeMessages.Add(new WelcomeMessage
            {
                NameSurname = appUser.Name + " " + appUser.Surname,
                Content = "Hoş Geldiniz",
            });
            _dbContext.SaveChanges();
        }
    }
}
