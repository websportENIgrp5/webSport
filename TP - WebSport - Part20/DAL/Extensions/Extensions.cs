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
                ? bos.Where(x => x != null).Select(x => x.ToBo(withJoin)).ToList()
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
                IdDifficulte = bo.IdDifficulte,
                
                Difficulte = withJoin && bo.Difficulte != null ? bo.Difficulte.ToBo() : null,
                Organisers = withJoin && bo.Contributors != null ? bo.Contributors.Where(x => x.IsOrganiser).Select(x => x.ToOrganiserBo()).ToList() : null,
                Competitors = withJoin && bo.Contributors != null ? bo.Contributors.Where(x => x.IsCompetitor).Select(x => x.ToCompetitorBo()).ToList() : null
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
                IdDifficulte = model.IdDifficulte
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

        public static List<Difficulte> ToBos(this List<DifficulteEntity> bos, bool withJoin = false)
        {
            return bos != null
                ? bos.Where(x => x != null).Select(x => x.ToBo(withJoin)).ToList()
                : null;
        }

        public static Difficulte ToBo(this DifficulteEntity bo, bool withJoin = false)
        {
            if (bo == null) return null;

            return new Difficulte
            {
                Id = bo.Id,
                Libelle = bo.Libelle
            };
        }

        public static List<Difficulte> ToDifficulteBos(this List<DifficulteEntity> bos)
        {
            return bos != null
                ? bos.Where(x => x != null).Select(x => x.ToDifficulteBo()).ToList()
                : null;
        }

        public static Difficulte ToDifficulteBo(this DifficulteEntity bo)
        {
            if (bo == null) return null;

            return new Difficulte
            {
                Id = bo.Id,
                Libelle = bo.Libelle
            };
        }

        public static DifficulteEntity ToDataEntity(this Difficulte model)
        {
            if (model == null) return null;

            return new DifficulteEntity
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
                Race = bo.Race.ToBo()
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
    }
}
