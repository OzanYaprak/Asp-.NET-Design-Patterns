using DesignPattern.DataAccessLayer.Abstract;
using DesignPattern.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericInterface<T> where T : class
    {
        #region Constructor

        private readonly DBContext _dbContext;

        public GenericRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public void Delete(T t)
        {
            _dbContext.Remove(t);
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            _dbContext.Add(t);
        }

        public void MultipleUpdate(List<T> t)
        {
            _dbContext.UpdateRange(t);
        }

        public void Update(T t)
        {
            _dbContext.Update(t);
        }

        #endregion
    }
}
