//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class RaecEntity
{
    public RaecEntity()
    {
        this.Contributors = new HashSet<ContributorEntity>();
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public System.DateTime DateStart { get; set; }
    public System.DateTime DateEnd { get; set; }
    public string Town { get; set; }

    public virtual ICollection<ContributorEntity> Contributors { get; set; }
}
