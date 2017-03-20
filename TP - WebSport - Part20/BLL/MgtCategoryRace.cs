using BO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MgtCategoryRace
    {
        #region Singleton

        private static MgtCategoryRace _instance;
        public static MgtCategoryRace GetInstance()
        {
            if (_instance == null)
                _instance = new MgtCategoryRace();
            return _instance;
        }

        #endregion

        #region Propriétés

        private List<CategoryRace> _listCategoryRace;

        private UnitOfWork _uow { get; set; }

        #endregion

        #region Constructeur

        public MgtCategoryRace()
        {

            // Récupération des données via la DAL (informations stockées dans une base de données SQL)
            _uow = new UnitOfWork();
            _listCategoryRace = _uow.CategoryRaceRepo.GetAllItems();
        }

        #endregion
    }
}
