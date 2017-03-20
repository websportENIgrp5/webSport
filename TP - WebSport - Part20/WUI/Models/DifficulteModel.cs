using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WUI.Models
{
    public class DifficulteModel
    {
        [Display(Name = "Identifiant")]
        public int Id { get; set; }

        [Display(Name = "Libelle")]
        public int Libelle { get; set; }
    }
}