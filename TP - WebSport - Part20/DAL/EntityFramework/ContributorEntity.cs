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
    
    public partial class ContributorEntity
    {
        public ContributorEntity()
        {
            this.Inscription = new HashSet<Inscription>();
        }
    
        public int PersonId { get; set; }
        public bool IsCompetitor { get; set; }
        public bool IsOrganiser { get; set; }
        public Nullable<int> IdUser { get; set; }
    
        public virtual PersonEntity Person { get; set; }
        public virtual ICollection<Inscription> Inscription { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}
