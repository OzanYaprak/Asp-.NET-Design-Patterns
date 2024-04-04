using DesignPattern.BusinessLayer.Service;
using DesignPattern.DataAccessLayer.Interface;
using DesignPattern.DataAccessLayer.UnitOfWork;
using DesignPattern.EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.BusinessLayer.Manager
{
    public class CustomerManager : ICustomerService
    {
        #region Constructor

        private readonly ICustomerInterface _customerInterface;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerManager(ICustomerInterface customerInterface, IUnitOfWork unitOfWork)
        {
            _customerInterface = customerInterface;
            _unitOfWork = unitOfWork;
        }


        #endregion

        public void Delete(Customer t)
        {
            _customerInterface.Delete(t);
            _unitOfWork.Save();
        }

        public Customer GetById(int id)
        {
            return _customerInterface.GetById(id);
        }

        public List<Customer> GetList()
        {
            return _customerInterface.GetList();
        }

        public void Insert(Customer t)
        {
            _customerInterface.Insert(t);
            _unitOfWork.Save();
        }

        public void MultipleUpdate(List<Customer> t)
        {
            _customerInterface.MultipleUpdate(t);
            _unitOfWork.Save();
        }

        public void Update(Customer t)
        {
            _customerInterface.Update(t);
            _unitOfWork.Save();
        }
    }
}
