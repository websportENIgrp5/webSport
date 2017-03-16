using BO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MgtDifficulte
    {
        #region Singleton

        private static MgtDifficulte _instance;
        public static MgtDifficulte GetInstance()
        {
            if (_instance == null)
                _instance = new MgtDifficulte();
            return _instance;
        }

        #endregion

        #region Propriétés

        private List<Difficulte> _listDifficulte;

        private UnitOfWork _uow { get; set; }

        #endregion

        #region Constructeur

        public MgtDifficulte()
        {

            // Récupération des données via la DAL (informations stockées dans une base de données SQL)
            _uow = new UnitOfWork();
            _listDifficulte = _uow.DifficulteRepo.GetAllItems();
        }

        #endregion
    }
}
