﻿using BO;
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
                DateEnd = bo.DateEnd,
                Town = bo.Town,

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
                DateEnd = model.DateEnd,
                Town = model.Town,
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
                DateEnd = entity.CDateEnd,
                Town = entity.CVille
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

        #region Poi

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bos"></param>
        /// <returns></returns>
        public static List<Poi> ToPoisBos(this List<PoiEntity> bos)
        {
            return bos != null
                 ? bos.Where(x => x != null).Select(x => x.ToPoiBo()).ToList()
                 : null;
        }

        /// <summary>
        /// Permet de convertir un PoiEntity en BO
        /// </summary>
        /// <param name="bo"></param>
        /// <returns></returns>
        public static Poi ToPoiBo(this PoiEntity bo)
        {
            return new Poi
            {
                Id = bo.Id,
                idCategory = bo.IdCategoriePoi,
                Longitude = bo.longitude,
                Latitude = bo.latitude,
            };
        }

        /// <summary>
        /// Permet de modifier une liste Poi en liste de PoiEntity
        /// </summary>
        /// <param name="pois">Liste poi</param>
        /// <returns></returns>
        public static List<PoiEntity> ToDataEntities(List<Poi> pois)
        {
            return pois != null
           ? pois.Where(x => x != null).Select(x => x.ToDataEntity()).ToList()
           : null;
        }

        /// <summary>
        /// Permet de convertir un Poi en PoiEntity
        /// </summary>
        /// <param name="poi"></param>
        /// <returns></returns>
        public static PoiEntity ToDataEntity(this Poi poi)
        {
            return new PoiEntity()
            {
                Id = poi.Id,
                latitude = poi.Latitude,
                longitude = poi.Longitude,
                IdCategoriePoi = poi.idCategory,
            };
        }
        #endregion
    }
}
