using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WUI.Models
{
    public class InscriptionModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "IdParticipant")]
        public int IdParticipant { get; set; }

        [Display(Name = "IdCourse")]
        //[Required(ErrorMessage = "La {0} est requise")]
        public int IdCourse { get; set; }

        [Display(Name = "idSuiviInscription")]
        public int idSuiviInscription { get; set; }

        [Display(Name = "NumClassement")]
        public int NumClassement { get; set; }

        [Display(Name = "Temps")]
        public char Temps { get; set; }
    }
}
