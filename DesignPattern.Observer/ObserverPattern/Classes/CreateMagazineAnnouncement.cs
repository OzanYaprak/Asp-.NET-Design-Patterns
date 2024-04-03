using DesignPattern.Observer.DataAccessLayer;
using DesignPattern.Observer.Models;
using System;

namespace DesignPattern.Observer.ObserverPattern.Classes
{
    public class CreateMagazineAnnouncement : IObserver
    {
        #region Constructor

        private readonly IServiceProvider _serviceProvider;
        DbContext _dbContext = new DbContext();

        public CreateMagazineAnnouncement(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        #endregion

        public void CreateNewUser(AppUser appUser)
        {
            _dbContext.UserProcesses.Add(new UserProcess
            {
                NameSurname = appUser.Name + " " + appUser.Surname,
                Magazine = "Bilim Dergisi",
                Content = "Bilim Dergimizin Mart Sayısı 1 Martta Evinize Ulaştırılacaktır."
            });
            _dbContext.SaveChanges();
        }
    }
}
