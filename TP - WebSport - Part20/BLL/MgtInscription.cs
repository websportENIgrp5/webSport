﻿using BO;
using DAL;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Extensions;

namespace BLL
{
    public class MgtInscription
    {
        #region Attributs
        private List<Inscription> _listRace;

        private static MgtInscription _instance;
        #endregion

        #region Propriétés
        private UnitOfWork _uow { get; set; }


        public static MgtInscription Instance
        {
            get
        {
            if (_instance == null)
                _instance = new MgtInscription();
            return _instance;
        }
        }
        #endregion

        #region Constructeur
        private MgtInscription()
        {
            _uow = new UnitOfWork();
        }

        #endregion


        #region Methods
        //public List<Inscription> getStatsByCategory()
        //{
        //    return DbInscription.GetInstance().getStatsByCategory(1, 1);
        //}

        public bool WriteInscription(int idCourse, string nameUser)
        {
            int idUser = _uow.UserRepo.GetIdByName(nameUser);

            Inscription inscri = new Inscription();
            inscri.IdCourse = idCourse;
            inscri.IdParticipant = _uow.ContributorRepo.Where(w => w.IdUser == idUser).Single().PersonId;
            inscri.IdSuiviInscription = 6;

            if(!_uow.InscriptionRepo.CheckAlreadyInscri(idCourse, inscri.IdParticipant))
            {
                _uow.InscriptionRepo.Add(inscri.ToDataEntity());
            }
            else
            {
                return false;
            }
            

            return true;
        }

        public List<Inscription> GetInscription(int idCourse, int rowstart, int numberSelect)
        {
            return _uow.InscriptionRepo.Where(x => x.IdCourse == idCourse).Skip(rowstart).Take(numberSelect).ToList().ToInscriptionBos();
        }

        public int GetNumberInscription(int idCourse)
        {
            DbInscription inscriptionDB = new DbInscription();
            return inscriptionDB.GetCountInscriByCourse(idCourse);

        }
        #endregion
    }
}
