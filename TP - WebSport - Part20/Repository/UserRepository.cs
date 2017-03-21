using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EntityFramework;

namespace Repository
{
    public class UserRepository : GenericRepository<UserTable>
    {
        #region Constructeurs
        public UserRepository(WebSportEntities context) : base(context)
        {

        }
        #endregion

        #region Methods

        /// <summary>
        /// Permet de retourner un id en fonction du userName
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetIdByName(string name)
        {
           var test = base.Where(user => user.Name.Equals(name)).Single();
           return test.Id;
        }
        #endregion
    }
}
