using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace BLL
{
    public class MgtPoi
    {
        public List<Poi> GetPoiByCourse(int id)
        {
            MgtPoiCategory catePoi = new MgtPoiCategory();
            List<Poi> pois = new List<Poi>()
            {
                new Poi(1, "-1.615006", "47.224170", catePoi.GetIdByName("depart")),
                new Poi(2, "-1.603029", "47.209926", catePoi.GetIdByName("checkPoint")),
                new Poi(3, "-1.597698", "47.229104", catePoi.GetIdByName("ravito")),
                new Poi(4, "-1.618012", "47.226532", catePoi.GetIdByName("checkPoint")),
                new Poi(5, "-1.618315", "47.224967", catePoi.GetIdByName("arrivee")),
        };
            return pois;
        }

        public string Convert(int idCourse)
        {
            StringBuilder stringReturned = new StringBuilder();
            foreach(Poi poi in GetPoiByCourse(idCourse))
            {
                switch(poi.idCategory)
                {
                    case 1:
                        stringReturned.Append("d:");
                        break;
                    case 2:
                        stringReturned.Append("r:");
                        break;
                    case 3:
                        stringReturned.Append("a:");
                        break;
                    case 4:
                        stringReturned.Append("c:");
                        break;
                }
                stringReturned.AppendFormat("{0},{1};", poi.Latitude, poi.Longitude);
            }

            return stringReturned.ToString();
        }
    }
}
