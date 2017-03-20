using DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace Repository
{
    public class PoiRepository : GenericRepository<PoiEntity>
    {
        #region Constructeur
        public PoiRepository(WebSportEntities context) : base(context)
        {

        }
        #endregion

        #region methods

        public List<Poi> GetOneByCourseId(int idCourse)
        {
            RaceRepository raceRepo = new RaceRepository(context);
            ICollection<Parcours> parcours = raceRepo.GetParcours(idCourse);
            List<Poi> parcoursPoi = new List<Poi>();
            foreach(Parcours par in parcours)
            {
                Poi poi = new Poi(par.Poi.Id, par.Poi.longitude, par.Poi.latitude, par.Poi.IdCategoriePoi);
                parcoursPoi.Add(poi);
            }

            return parcoursPoi;
        }
        #endregion
    }
}
