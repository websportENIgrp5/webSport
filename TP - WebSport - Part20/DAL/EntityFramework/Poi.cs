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
    
    public partial class Poi
    {
        public Poi()
        {
            this.Parcours1 = new HashSet<Parcours>();
        }
    
        public int Id { get; set; }
        public int IdCategoriePoi { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
    
        public virtual CategoriePoi CategoriePoi { get; set; }
        public virtual ICollection<Parcours> Parcours1 { get; set; }
    }
}
