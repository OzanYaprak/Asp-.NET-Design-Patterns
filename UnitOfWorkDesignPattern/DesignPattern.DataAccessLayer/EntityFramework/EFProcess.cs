using DesignPattern.DataAccessLayer.Context;
using DesignPattern.DataAccessLayer.Interface;
using DesignPattern.DataAccessLayer.Repositories;
using DesignPattern.EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DataAccessLayer.EntityFramework
{
    public class EFProcess : GenericRepository<Process>,IProcessInterface
    {
        public EFProcess(DBContext dBContext) : base(dBContext) 
        {
        }
    }
}
