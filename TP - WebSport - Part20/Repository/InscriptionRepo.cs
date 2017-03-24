using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL.EntityFramework;
using DAL.Extensions;

namespace Repository
{
    public class InscriptionRepo : GenericRepository<InscriptionEntity>
    {
        public InscriptionRepo(WebSportEntities context) : base(context)
        {

        }

        public void AddInscription(InscriptionEntity inscription)
        {
            base.Add(inscription);
        }
        public bool  CheckAlreadyInscri(int idCourse, int idUser)
        {
           if(base.context.Inscription.Where(i => i.IdCourse == idCourse && i.IdParticipant == idUser).Count() == 0)
            {
                return false;
            }
           else
            {
                return true;
            }
        }

            
    }
}
