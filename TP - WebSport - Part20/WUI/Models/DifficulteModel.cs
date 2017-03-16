using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WUI.Models
{
    public class DifficulteModel
    {
        [Display(Name = "Identifiant")]
        public int Id { get; set; }

        [Display(Name = "Libelle")]
        public String Libelle { get; set; }

        //private readonly List<DifficulteModel> _difficultes;

        //[Display(Name = "Niveaux")]
        //public int SelectedDifficulteId { get; set; }

        //public IEnumerable<SelectListItem> Difficultes
        //{
        //    //get
        //    //{
        //    //    var allDifficultes = _difficulte.Select(d => new SelectListItem
        //    //    {
        //    //        Value = d.Id.ToString(),
        //    //        Text = d.Libelle
        //    //    });
        //    //    return allDifficultes;
        //    //}

        //    get { return new SelectList(_difficultes, "Id", "Libelle"); }
        //}
    }
}