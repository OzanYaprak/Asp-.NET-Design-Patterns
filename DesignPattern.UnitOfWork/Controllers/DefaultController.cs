using DesignPattern.BusinessLayer.Service;
using DesignPattern.EntityLayer.Entity;
using DesignPattern.UnitOfWork.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DesignPattern.UnitOfWork.Controllers
{
    public class DefaultController : Controller
    {
        #region Constructor

        private readonly ICustomerService _customerService;

        public DefaultController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        #endregion

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CustomerViewModel customerViewModel)
        {
            var senderId = _customerService.GetById(customerViewModel.SenderId);
            var receiverId = _customerService.GetById(customerViewModel.ReceiverId);

            if (senderId.CustomerBalance <= 0)
            {
                ViewBag.BakiyeYetersiz = "Bu işlem için bakiyeniz yetersiz.";
                return View();
            }
            if (customerViewModel.Amount > senderId.CustomerBalance)
            {
                ViewBag.FazlaMiktarGonderim = "Girilen miktar mevcut bakiyenizden fazla olamaz.";
                return View();
            }

            senderId.CustomerBalance -= customerViewModel.Amount;
            receiverId.CustomerBalance += customerViewModel.Amount;

            List<Customer> updatedCustomers = new List<Customer>() { senderId, receiverId };

            _customerService.MultipleUpdate(updatedCustomers);

            return Index();
        }
    }
}
