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
    public class PersonRepository : GenericRepository<PersonEntity>
    {
        #region Constructeurs
        public PersonRepository(WebSportEntities context) : base(context)
        {

        }
        #endregion

        #region Methods

        public Personne GetById(int id)
        {
            var person = this.GetByIdPrivate(id);
            return person != null ? person.ToBoId() : null;
        }

        private PersonEntity GetByIdPrivate(int id)
        {
            return base.Where(x => x.Id == id).SingleOrDefault();
        }

        public void Update(Personne element)
        {
            var raceToUpdate = this.GetByIdPrivate(element.Id);
            raceToUpdate.Lastname = element.Nom;
            raceToUpdate.Firstname = element.Prenom;
            raceToUpdate.NomImage = element.NomImage;
            base.Update(raceToUpdate);
        }
        #endregion
    }
}
