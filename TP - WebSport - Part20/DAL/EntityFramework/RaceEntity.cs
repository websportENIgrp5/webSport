//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class RaceEntity
    {
        public RaceEntity()
        {
            this.Inscription = new HashSet<Inscription>();
            this.Parcours = new HashSet<Parcours>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime DateStart { get; set; }
        public string Town { get; set; }
        public Nullable<int> IdDifficulte { get; set; }
        public Nullable<int> Distance { get; set; }
        public Nullable<int> IdCategorieCourse { get; set; }
        public Nullable<System.TimeSpan> HeureStart { get; set; }
        public Nullable<System.TimeSpan> HeureEnd { get; set; }
    
        public virtual CategorieCourse CategorieCourse { get; set; }
        public virtual Difficulte Difficulte { get; set; }
        public virtual ICollection<Inscription> Inscription { get; set; }
        public virtual ICollection<Parcours> Parcours { get; set; }
    }
}
