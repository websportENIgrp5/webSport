using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using Repository;

namespace BLL
{
    public class MgtPoi
    {
        #region Attributs
        private UnitOfWork _uow;
        #endregion

        #region Propriétés
        public List<Poi> GetPoiByCourse(int id)
        {
            MgtPoiCategory catePoi = new MgtPoiCategory();
            UnitOfWork uow = new UnitOfWork();
            return uow.poiRepo.GetOneByCourseId(id);
           
        }
        #endregion

        #region Constructeur
        public MgtPoi()
        {
            _uow = new UnitOfWork();
        }
        #endregion

        #region methodes
        public string Convert(int idCourse)
        {
            StringBuilder stringReturned = new StringBuilder();
            List<Poi> pois = GetPoiByCourse(idCourse);
            if(pois.Count > 0)
            {
                foreach (Poi poi in pois)
                {
                    switch (poi.idCategory)
                    {
                        case 1:
                            stringReturned.Append("d:");
                            break;
                        case 2:
                            stringReturned.Append("a:");
                            break;
                        case 3:
                            stringReturned.Append("c:");
                            break;
                        case 4:
                            stringReturned.Append("r:");
                            break;
                    }
                    stringReturned.AppendFormat("{0},{1};", poi.Longitude, poi.Latitude);
                }
            }
            else
            {
                 stringReturned.Append("NoPar");
            }
            return stringReturned.ToString();
        }
        
        
        #endregion
    }
}
