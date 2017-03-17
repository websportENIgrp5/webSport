using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WUI.Models;

namespace WUI.Extensions
{
    public static class Extensions
    {
        #region CategoryRace

        public static List<CategoryRaceModel> ToModels(this List<CategoryRace> bos)
        {
            return bos != null
                ? bos.Where(x => x != null).Select(x => x.ToModel()).ToList()
                : null;
        }

        public static CategoryRaceModel ToModel(this CategoryRace bo)
        {
            if (bo == null) return null;

            return new CategoryRaceModel
            {
                Id = bo.Id,
                Title = bo.Title
            };
        }

        public static CategoryRace ToBo(this CategoryRaceModel model)
        {
            if (model == null) return null;

            return new CategoryRace
            {
                Id = model.Id,
                Title = model.Title
            };
        }

        #endregion

        #region Competitor

        public static List<CompetitorModel> ToModels(this List<Competitor> bos)
        {
            return bos != null
                ? bos.Where(x => x != null).Select(x => x.ToModel()).ToList()
                : null;
        }

        public static CompetitorModel ToModel(this Competitor bo)
        {
            if (bo == null) return null;

            return new CompetitorModel
            {   
                Id = bo.Id,
                Nom = bo.Nom,
                Prenom = bo.Prenom,
                DateNaissance = bo.DateNaissance,
                Email = bo.Email,
                Phone = bo.Phone,
                Race = bo.Race.ToModel(),
                DisplayConfigurations = bo.DisplayConfigurations.Select(x => x.ToModel()).ToList()
            };
        }

        #endregion

        #region Difficulte
        public static List<DifficulteModel> ToModels(this List<Difficulte> bos)
        {
            return bos != null
                ? bos.Where(x => x != null).Select(x => x.ToModel()).ToList()
                : null;
        }

        public static DifficulteModel ToModel(this Difficulte bo)
        {
            if (bo == null) return null;

            return new DifficulteModel
            {
                Id = bo.Id,
                Libelle = bo.Libelle
            };
        }

        public static Difficulte ToBo(this DifficulteModel model)
        {
            if (model == null) return null;

            return new Difficulte
            {
                Id = model.Id,
                Libelle = model.Libelle
            };
        }
        #endregion

        #region Race

        public static List<RaceModel> ToModels(this List<Race> bos, bool withJoin = false)
        {
            return bos != null
                ? bos.Where(x => x != null).Select(x => x.ToModel(withJoin)).ToList()
                : null;
        }

        public static RaceModel ToModel(this Race bo, bool withJoin = false)
        {
            if (bo == null) return null;

            return new RaceModel
            {
                Id = bo.Id,
                Title = bo.Title,
                Description = bo.Description,
                DateStart = bo.DateStart,
                Town = bo.Town,
                Distance = bo.Distance,

                Difficulte = withJoin && bo.Difficulte != null ? bo.Difficulte.ToModel() : null,
                CategoryRace = withJoin && bo.CategoryRace != null ? bo.CategoryRace.ToModel() : null
            };
        }

        public static Race ToBo(this RaceModel model)
        {
            if (model == null) return null;

            return new Race
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                DateStart = model.DateStart,
                Town = model.Town,
                Distance = model.Distance,

                Difficulte = model.Difficulte.ToBo(),
                CategoryRace = model.CategoryRace.ToBo()
            };
        }

        #endregion

        #region DisplayConfiguration

        public static List<DisplayConfigurationModel> ToModels(this List<DisplayConfiguration> bos)
        {
            return bos != null
                ? bos.Where(x => x != null).Select(x => x.ToModel()).ToList()
                : null;
        }

        public static DisplayConfigurationModel ToModel(this DisplayConfiguration bo)
        {
            if (bo == null) return null;

            return new DisplayConfigurationModel
            {
                Id = bo.Id,
                PersonneId = bo.PersonneId,
                DeviceName = bo.DeviceName,
                SpeedAvg = bo.SpeedAvg,
                SpeedMax = bo.SpeedMax,
                UnitDistance = bo.UnitDistance.ToModel(),

                Person = bo.Person.ToModel()
            };
        }

        #endregion

        #region Personne
        public static PersonneModel ToModel(this Personne bo)
        {
            if (bo == null) return null;

            return new PersonneModel
            {
                Id = bo.Id,
                Nom = bo.Nom,
                Prenom = bo.Prenom,
                DateNaissance = bo.DateNaissance,
                Email = bo.Email,
                Phone = bo.Phone,

                //DisplayConfigurations = bo.DisplayConfigurations.Select(x => x.ToModel()).ToList()
            };
        }
        #endregion
       
        #region Organisateur
        public static OrganizerModel ToModel(this Organizer bo)
        {
            if (bo == null) return null;

            return new OrganizerModel
            {
                Id = bo.Id,
                Nom = bo.Nom,
                Prenom = bo.Prenom,
                DateNaissance = bo.DateNaissance,
                Email = bo.Email,
                Phone = bo.Phone,
                DisplayConfigurations = bo.DisplayConfigurations.Select(x => x.ToModel()).ToList()
            };
        }
        #endregion

        #region Poi
        /// <summary>
        /// Permet de convertir un Bo Poi en Poi Model
        /// </summary>
        /// <param name="bo"></param>
        /// <returns></returns>
        public static PoiModel ToModel(this Poi bo)
        {
            if (bo == null) return null;

            return new PoiModel
            {
                Id = bo.Id,
                Latitude = bo.Latitude,
                Longitude = bo.Longitude,
                Category = bo.idCategory,

            };
        }
        

        public static Poi toBo(this PoiModel model)
        {
            if (model == null) return null;

            return new Poi()
            {
                Id = model.Id,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                idCategory = model.Category,
            };
        }
        #endregion


        public static UnitDistanceModel ToModel(this UnitDistance bo)
        {
            UnitDistanceModel result;

            switch (bo)
            {
                case UnitDistance.Miles:
                    result = UnitDistanceModel.Miles;
                    break;

                default:
                case UnitDistance.Kilometers:
                    result = UnitDistanceModel.Kilometers;
                    break;
            }

            return result;
        }
    }
}