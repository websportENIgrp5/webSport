using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EntityFramework;
using DAL.Extensions;
using BO;

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

        public User GetById(int id)
        {
            var user = this.GetByIdPrivate(id);
            return user != null ? user.ToBoId() : null;
        }

        private UserTable GetByIdPrivate(int id)
        {
            return base.Where(x => x.Id == id).SingleOrDefault();
        }

        public void Update(User element)
        {
            var raceToUpdate = this.GetByIdPrivate(element.Id);
            raceToUpdate.Name = element.Login;
            base.Update(raceToUpdate);
        }
        #endregion
    }
}
