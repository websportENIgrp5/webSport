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

        public int? NumClassement { get; set; }

        public Nullable<TimeSpan> Temps { get; set; }

        public User User { get; set; }

        public Competitor Competitor { get; set; }
    }
}
