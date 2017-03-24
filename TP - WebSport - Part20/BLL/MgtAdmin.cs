using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using DAL;
using BO;

namespace BLL
{
    public class MgtAdmin
    {
        private UnitOfWork _uow;

        public MgtAdmin()
        {
            _uow = new UnitOfWork();
        }
    }
}
