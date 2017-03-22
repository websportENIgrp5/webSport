using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WUI.Models
{
    /// <summary>
    /// Inscription d'un compétiteur à une course
    /// </summary>
    public class InscriptionModel
    {
        public int Id { get; set; }

        public int IdCourse { get; set; }

        public int IdParticipant { get; set; }

        public int IdSuiviInscription { get; set; }

        public int? NumClassement { get; set; }

        public CompetitorModel Competitor { get; set; }

        public List<OrganizerModel> Organisers { get; set; }

        public Nullable<TimeSpan> Temps { get; set; }
    }
}