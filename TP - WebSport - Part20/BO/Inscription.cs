using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    [Serializable]
    public class Inscription
    {
        public int Id { get; set; }

        public int IdParticipant { get; set; }

        public int IdCourse { get; set; }

        public int IdSuiviInscription { get; set; }

        public int NumClassement { get; set; }

        public char Temps { get; set; }
    }
}
