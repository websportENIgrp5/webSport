using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class CategoryRace
    {
        public int Id { get; set; }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }


        public CategoryRace()
        {
        }

        public CategoryRace(string title)
        {
            Title = title;
        }


        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(CategoryRace))
            {
                return Id == ((CategoryRace)obj).Id
                       && Title == ((CategoryRace)obj).Title;
            }
            else
            {
                return false;
            }
        }
    }
}
