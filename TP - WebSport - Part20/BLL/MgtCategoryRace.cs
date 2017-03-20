using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MgtCategoryRace
    {
        public List<CategoryRace> GetCategory()
        {
            // TODO : Aller chercher ces informations en BDD via la DAL
            var result = new List<CategoryRace>
            {
                new CategoryRace { Id = 1, Title = "RaceEntity à pied" },
                new CategoryRace { Id = 2, Title = "Gym" },
                new CategoryRace { Id = 3, Title = "Fitness" },
                new CategoryRace { Id = 4, Title = "Cyclisme" }
            };

            return result;
        }

        // CREATE

        // UPDATE

        // DELETE
    }
}
