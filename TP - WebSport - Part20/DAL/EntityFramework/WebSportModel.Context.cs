﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using DAL.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

public partial class WebSportEntities : DbContext
{
    public WebSportEntities()
        : base("name=WebSportEntities")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }

    public DbSet<RaceEntity> RaceEntities { get; set; }
    public DbSet<ContributorEntity> ContributorEntities { get; set; }
    public DbSet<PersonEntity> PersonEntities { get; set; }
    public DbSet<CategorieCourse> CategorieCourse { get; set; }
    public DbSet<CategoriePoi> CategoriePoi { get; set; }
    public DbSet<Difficulte> Difficulte { get; set; }
    public DbSet<Inscription> Inscription { get; set; }
    public DbSet<Parcours> Parcours { get; set; }
    public DbSet<Poi> Poi { get; set; }
    public DbSet<SuiviInscription> SuiviInscription { get; set; }
    public DbSet<UserTable> UserTable { get; set; }
}
