using BO;
using DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DAL.Extensions
{
    public static class Extensions
    {
        #region Race

        public static List<Race> ToBos(this List<RaceEntity> bos, bool withJoin = false)
        {
            return bos != null
                ? bos.Where(x => x != null && x.DateStart >= DateTime.Today).Select(x => x.ToBo(withJoin)).ToList()
                : null;
        }

        public static Race ToBo(this RaceEntity bo, bool withJoin = false)
        {
            if (bo == null) return null;

            return new Race
            {
                Id = bo.Id,
                Title = bo.Title,
                Description = bo.Description,
                DateStart = bo.DateStart,
                Town = bo.Town,
                Distance = bo.Distance,
                HeureStart = bo.HeureStart,
                HeureEnd = bo.HeureEnd,
                Reglement = bo.Reglement,
                IdDifficulte = bo.IdDifficulte,
                IdCategoryRace = bo.IdCategorieCourse,

                Difficulte = bo.Difficulte != null ? bo.Difficulte.ToBo() : null,
                CategoryRace = bo.CategorieCourse != null ? bo.CategorieCourse.ToBo() : null,
                Inscriptions = bo.Inscription != null ? bo.Inscription.Where(x => x.IdCourse == bo.Id).Select(x => x.ToInscriptionBo()).ToList() : null,
            };
        }

        public static Race ToBoId(this RaceEntity bo, bool withJoin = false)
        {
            if (bo == null) return null;

            return new Race
            {
                Id = bo.Id,
                Title = bo.Title,
                Description = bo.Description,
                DateStart = bo.DateStart,
                Town = bo.Town,
                Distance = bo.Distance,
                HeureStart = bo.HeureStart,
                HeureEnd = bo.HeureEnd,
                Reglement = bo.Reglement,
                IdDifficulte = bo.IdDifficulte,
                IdCategoryRace = bo.IdCategorieCourse,

                Difficulte = bo.Difficulte != null ? bo.Difficulte.ToBo() : null,
                CategoryRace = bo.CategorieCourse != null ? bo.CategorieCourse.ToBo() : null,
                Inscriptions = bo.Inscription != null ? bo.Inscription.Where(x => x.IdCourse == bo.Id).Select(x => x.ToInscriptionBo()).ToList() : null,
            };
        }


        public static RaceEntity ToDataEntity(this Race model)
        {
            if (model == null) return null;

            return new RaceEntity
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                DateStart = model.DateStart,
                Town = model.Town,
                Distance = model.Distance,
                IdDifficulte = model.IdDifficulte,

                Difficulte = model.ToDataEntity().Difficulte
            };
        }


        public static Race ToBo(this GetRaceById_Result entity)
        {
            if (entity == null) return null;

            return new Race
            {
                Id = entity.CId,
                Title = entity.CTitre,
                Description = entity.CDescription,
                DateStart = entity.CDateStart,
                Town = entity.CVille,
                Distance = entity.Distance,
                IdDifficulte = entity.IdDifficulte
            };
        }

        #endregion

        #region Difficulte

        public static List<BO.Difficulte> ToBos(this List<EntityFramework.Difficulte> bos, bool withJoin = false)
        {
            return bos != null
                ? bos.Where(x => x != null).Select(x => x.ToBo(withJoin)).ToList()
                : null;
        }

        public static BO.Difficulte ToBo(this EntityFramework.Difficulte bo, bool withJoin = false)
        {
            if (bo == null) return null;

            return new BO.Difficulte
            {
                Id = bo.Id,
                Libelle = bo.Libelle
            };
        }

        public static List<BO.Difficulte> ToDifficulteBos(this List<EntityFramework.Difficulte> bos)
        {
            return bos != null
                ? bos.Where(x => x != null).Select(x => x.ToDifficulteBo()).ToList()
                : null;
        }

        public static BO.Difficulte ToDifficulteBo(this EntityFramework.Difficulte bo)
        {
            if (bo == null) return null;

            return new BO.Difficulte
            {
                Id = bo.Id,
                Libelle = bo.Libelle
            };
        }

        public static BO.Difficulte ToDataEntity(this EntityFramework.Difficulte model)
        {
            if (model == null) return null;

            return new BO.Difficulte
            {
                Id = model.Id,
                Libelle = model.Libelle
           
            };
        }


        //public static Difficulte ToBo(this GetDifficulteById_Result entity)
        //{
        //    if (entity == null) return null;

        //    return new Difficulte
        //    {
        //        Id = entity.CId,
        //        Libelle = entity.CLibelle,
        //    };
        //}

        #endregion

        #region CategoryRace

        public static List<CategoryRace> ToBos(this List<CategorieCourse> bos, bool withJoin = false)
        {
            return bos != null
                ? bos.Where(x => x != null).Select(x => x.ToBo(withJoin)).ToList()
                : null;
        }

        public static CategoryRace ToBo(this CategorieCourse bo, bool withJoin = false)
        {
            if (bo == null) return null;

            return new CategoryRace
            {
                Id = bo.Id,
                Title = bo.Libelle
            };
        }

        public static List<CategoryRace> ToCategoryRaceBos(this List<CategoryRace> bos)
        {
            return bos != null
                ? bos.Where(x => x != null).Select(x => x.ToCategoryRaceBo()).ToList()
                : null;
        }

        public static CategoryRace ToCategoryRaceBo(this CategoryRace bo)
        {
            if (bo == null) return null;

            return new CategoryRace
            {
                Id = bo.Id,
                Title = bo.Title
            };
        }

        public static CategorieCourse ToDataEntity(this CategoryRace model)
        {
            if (model == null) return null;

            return new CategorieCourse
            {
                Id = model.Id,
                Libelle = model.Title

            };
        }

        #endregion

        #region Inscription

        public static List<Inscription> ToInscriptionBos(this List<InscriptionEntity> bos)
        {
            return bos != null
                ? bos.Where(x => x != null).Select(x => x.ToInscriptionBo()).ToList()
                : null;
        }

        public static Inscription ToInscriptionBo(this InscriptionEntity bo)
        {
            if (bo == null) return null;

            return new Inscription
            {
                Id = bo.Id,
                IdCourse = bo.IdCourse,
                IdParticipant = bo.IdParticipant,
                IdSuiviInscription = bo.IdSuiviInscription,
                NumClassement = bo.NumClassement,
                Temps = bo.Temps,
                Competitor = bo.Participant.ToCompetitorBo()
            };
        }

        #endregion

        #region User

        public static User ToDataEntity(this UserTable model)
        {
            if (model == null) return null;

            return new User
            {
                Id = model.Id,
                Login = model.Name
            };
        }

        public static User ToBoId(this UserTable bo, bool withJoin = false)
        {
            if (bo == null) return null;

            return new User
            {
                Id = bo.Id,
                Login = bo.Name
            };
        }

        #endregion

        #region Competitor

        public static List<Competitor> ToCompetitorBos(this List<ContributorEntity> bos)
        {
            return bos != null
                ? bos.Where(x => x != null).Select(x => x.ToCompetitorBo()).ToList()
                : null;
        }

        public static Competitor ToCompetitorBo(this ContributorEntity bo)
        {
            if (bo == null) return null;

            return new Competitor
            {
                Id = bo.PersonId,
                Nom = bo.Person.Lastname,
                Prenom = bo.Person.Firstname,
                DateNaissance = bo.Person.BirthDate.HasValue ? bo.Person.BirthDate.Value : DateTime.MinValue,
                Email = bo.Person.Mail,
                Phone = bo.Person.Phone,
                User = bo.UserTable.ToDataEntity()
            };
        }


        #endregion

        #region Organizer

        public static List<Organizer> ToOrganiserBos(this List<ContributorEntity> bos)
        {
            return bos != null
                ? bos.Where(x => x != null).Select(x => x.ToOrganiserBo()).ToList()
                : null;
        }

        public static Organizer ToOrganiserBo(this ContributorEntity bo)
        {
            if (bo == null) return null;

            return new Organizer
            {
                Id = bo.PersonId,
                Nom = bo.Person.Lastname,
                Prenom = bo.Person.Firstname,
                DateNaissance = bo.Person.BirthDate.HasValue ? bo.Person.BirthDate.Value : DateTime.MinValue,
                Email = bo.Person.Mail,
                Phone = bo.Person.Phone
            };
        }

        #endregion

        #region Person

        public static Personne ToBoId(this PersonEntity bo, bool withJoin = false)
        {
            if (bo == null) return null;

            return new Personne
            {
                Id = bo.Id,
                Nom = bo.Lastname,
                Prenom = bo.Firstname,
                DateNaissance = bo.BirthDate.HasValue ? bo.BirthDate.Value : DateTime.MinValue,
                Email = bo.Mail,
                Phone = bo.Phone
            };
        }

        #endregion

        #region Poi
        //public static List<Poi> toBos(this List<PoiEntity> pois)
        //{
        //    return pois != null
        //       ? pois.Where(x => x != null).Select(x => x.ToOrganiserBo()).ToList()
        //       : null;
        //}

        //public static Poi toBo(this PoiEntity poi)
        //{
        //    return new Poi()
        //    {
        //        Id = poi.Id
        //    }
        //}

        #endregion

        #region Inscription

        public static InscriptionEntity ToDataEntity(this Inscription bo)
        {
            
            InscriptionEntity de = new InscriptionEntity();
            de.IdCourse = bo.IdCourse;
            de.IdParticipant = bo.IdParticipant;
            de.IdSuiviInscription = bo.IdSuiviInscription;
            if(bo.Temps != null )
                de.Temps = bo.Temps;
            if(bo.NumClassement !=null)
            de.NumClassement = bo.NumClassement;

            return de;
        }
        #endregion
    }
}
