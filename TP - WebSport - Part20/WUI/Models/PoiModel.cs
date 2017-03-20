using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WUI.Models
{
    /// <summary>
    /// Poi : Point d'intérêt = Localisation GPS associée à une catégorie : Départ, Arrivée, Ravitaillement...
    /// </summary>
    public class PoiModel
    {
        #region Attributs
        private int id;
        private CategoryPoiModel category;
        private string longitude;
        private string latitude;
        #endregion

        #region Propriétés
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Longitude
        {
            get { return longitude; }
            set
            {
                if (value.Length > 15)
                {
                    value.Substring(0, 15);
                }
                longitude = value;      
            }
        }

        public string Latitude
        {
            get { return latitude; }
            set
            {
                if (value.Length > 15)
                {
                    value.Substring(0, 15);
                }
                latitude = value;
            }

        }

        public int Category
        {
            get { return category.Id; }
            set { category = new CategoryPoiModel(value); }
        }
        public string CategoryName
    {
            get { return category.Name; }
        }
        #endregion

    }
}