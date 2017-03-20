using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class PoiCategory
    {
        private int _id;
        private string _name;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public PoiCategory()
        {

        }

        public PoiCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
