using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL.EntityFramework;
using DAL;
using Repository;

namespace BLL
{
    public class MgtAccount
    {
        private UnitOfWork _uow;

        public MgtAccount()
        {
            _uow = new UnitOfWork();
        }

        public List<InscriRaceSuivi> GetLast3InscriByUserName(string name)
        {
            int idUser = _uow.UserRepo.GetIdByName(name);
            int idParticipant = _uow.ContributorRepo.Where(x => x.IdUser == idUser).Single().PersonId;

            DbInscription dbInscription = new DbInscription();
            return dbInscription.GetLast3Race(idParticipant);
        }

        public List<InscriRaceSuivi> GetInscriByUserName(string name)
        {
            int idUser = _uow.UserRepo.GetIdByName(name);
            int idParticipant = _uow.ContributorRepo.Where(x => x.IdUser == idUser).Single().PersonId;

            DbInscription dbInscription = new DbInscription();
            return dbInscription.GetInscriByIdParticipant(idParticipant);
        }

        public List<UserStats> GetUserStats(string name, int category)
        {
            int idUser = _uow.UserRepo.GetIdByName(name);
            int idParticipant = _uow.ContributorRepo.Where(x => x.IdUser == idUser).Single().PersonId;

            DbInscription dbInscription = new DbInscription();

            return dbInscription.getStatsByCategory(idParticipant, category);
        }

        public List<int> GetCategoriesId()
        {
            DbInscription dbInscription = new DbInscription();

            return dbInscription.getCategoriesId();
        }
    }
}
