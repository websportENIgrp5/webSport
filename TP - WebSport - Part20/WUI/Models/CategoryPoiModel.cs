using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WUI.Models
{
    public class CategoryPoiModel
    {
        private int id;
        private string name;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public CategoryPoiModel(int id)
        {
            Id = id;
        }
    }
}