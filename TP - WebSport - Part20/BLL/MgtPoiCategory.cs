using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace BLL
{
    public class MgtPoiCategory
    {
        private List<PoiCategory> _category;

        public List<PoiCategory> GetCategory {
            get
            {
                List<PoiCategory> catePoi = new List<PoiCategory>()
                {
                    new PoiCategory(1,"depart"),
                    new PoiCategory(2,"ravito"),
                    new PoiCategory(3,"arrivee"),
                    new PoiCategory(4,"checkPoint"),
                };
                return catePoi;
            }
          }


        public MgtPoiCategory()
        {
            _category = GetCategory;
        }

        public int GetIdByName(string name)
        {
            foreach(PoiCategory catePoi in _category)
            {
                if(catePoi.Name.Equals(name))
                {
                    return catePoi.Id;
                }
            }
            return -1;
        }

    }
}
