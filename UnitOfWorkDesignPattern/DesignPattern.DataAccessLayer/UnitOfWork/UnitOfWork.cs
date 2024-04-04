using DesignPattern.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Constructor

        private readonly DBContext _dbContext;

        public UnitOfWork(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        #endregion
    }
}
