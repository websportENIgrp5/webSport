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

        public Personne GetIdentityPerson(int idUser)
        {
            int idParticipant = _uow.ContributorRepo.Where(x => x.IdUser == idUser).Single().PersonId;
            Personne Person = _uow.PersonRepo.GetById(idParticipant);

            return Person;
        }

        public void DeleteInscription(int idInscri)
        {
            DbInscription dbInscrition = new DbInscription();
            dbInscrition.Remove(idInscri);
        }

        public bool ChangeIdentity(string userName, string login, string lastname, string firstname)
        {
            // Mise à jour du login
            int idUser = _uow.UserRepo.GetIdByName(userName);
            User User = _uow.UserRepo.GetById(idUser);
            if(login != null)
            {
                User.Login = login;
            }
           
            _uow.UserRepo.Update(User);


            // Mise à jour du nom et prénom 
            int idParticipant = _uow.ContributorRepo.Where(x => x.IdUser == idUser).Single().PersonId;
            Personne Person = _uow.PersonRepo.GetById(idParticipant);
            if(lastname != null)
            {
                Person.Nom = lastname;
            }
            
            if(firstname != null)
            {
                Person.Prenom = firstname;
            }
            
            _uow.PersonRepo.Update(Person);

            _uow.Save();

            return true;
        }

        public bool AjoutImageProfil(int idUser, string nomImage)
        {
            int idParticipant = _uow.ContributorRepo.Where(x => x.IdUser == idUser).Single().PersonId;
            Personne Person = _uow.PersonRepo.GetById(idParticipant);
            if(nomImage != null)
            {
                Person.NomImage = nomImage;
            }

            _uow.PersonRepo.Update(Person);

            _uow.Save();

            return true;
        }

        public string GetImageProfil(int idUser)
        {
            int idParticipant = _uow.ContributorRepo.Where(x => x.IdUser == idUser).Single().PersonId;
            Personne Person = _uow.PersonRepo.GetById(idParticipant);
            if(Person.NomImage != null)
            {
                return Person.NomImage;
            }

            return null;
        }
    }
}
