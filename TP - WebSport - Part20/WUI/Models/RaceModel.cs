using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WUI.Models.Attributes;


namespace WUI.Models
{
    /// <summary>
    /// RaceEntity
    /// </summary>
    public class RaceModel
    {
        [Display(Name = "Identifiant")]
        public int Id { get; set; }

        [Display(Name = "Titre")]
        [Required(ErrorMessage = "Le {0} est requis")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        [StringLength(200, MinimumLength=20, ErrorMessage="La {0} doit faire au minimum 20 caractères")]
        [Required(ErrorMessage = "La {0} est requise")]
        public string Description { get; set; }

        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        // Par défaut, une date est requise car le type DateTime n'est pas "Nullable"
        public DateTime DateStart { get; set; }
        
        [Display(Name = "Ville")]
        [Required(ErrorMessage = "La {0} est requise")]
        public string Town { get; set; }

        [Display(Name = "Distance")]
        [Required(ErrorMessage = "La {0} est requise")]
        public int? Distance { get; set; }

        [Display(Name = "Heure de départ prévue")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "L'{0} est requise")]
        public Nullable<TimeSpan> HeureStart { get; set; }

        [Display(Name = "Heure de d'arrivée prévue")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "L'{0} est requise")]
        public Nullable<TimeSpan> HeureEnd { get; set; }

        public String Reglement { get; set; }


        [Display(Name = "Niveau")]
       // [Required(ErrorMessage = "La {0} est requise")]
        public DifficulteModel Difficulte { get; set; }

        [Display(Name = "Catégorie")]
       // [Required(ErrorMessage = "La {0} est requise")]
        public CategoryRaceModel CategoryRace { get; set; }

        public List<InscriptionModel> Inscriptions { get; set; }

        public List<PoiModel> Pois { get; set; }


        //public List<DifficulteModel> _difficultes { get; set; }

        //[Display(Name = "Niveaux")]
        //public int SelectedDifficulteId { get; set; }

        //public IEnumerable<SelectListItem> Difficultes
        //{
        //    //get
        //    //{
        //    //    var allDifficultes = _difficultes.Select(d => new SelectListItem
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
