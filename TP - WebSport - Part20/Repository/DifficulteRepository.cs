using BO;
using DAL.EntityFramework;
using DAL.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DifficulteRepository : GenericRepository<DAL.EntityFramework.Difficulte>
    {

        #region Constructor

        public DifficulteRepository(WebSportEntities context)
            : base(context)
        {
        }

        #endregion

        #region Public methods

        //public int Add(BO.Difficulte element)
        //{
        //    try
        //    {
        //        var result = base.Add(element.ToDataEntity());
        //        return result.Id;
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}

        public List<BO.Difficulte> GetAllItems()
        {
            return base.GetAll().ToBos();
        }

        #endregion
    }
}
