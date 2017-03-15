using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    [Serializable]
    /// <summary>
    /// Poi : Point d'intérêt = Localisation GPS associée à une catégorie : Départ, Arrivée, Ravitaillement...
    /// </summary>
    public class Poi
    {
        #region Attributs

        private int _id;
        private int _idCategory;
        private string _long;
        private string _lat;

        #endregion

        #region Propriétés
        
        public int Id
        {
            get { return _id; }
            set { _id = value; }

        }
        /// <summary>
        /// Gets or Sets the value of Category of this Poi(start, end)
        /// </summary>
        public int idCategory
        {
            get { return _idCategory; }
            set { _idCategory = value; }
        }

        /// <summary>
        /// Gets or Sets the value of the longitude
        /// </summary>
        public string Longitude
        {
            get { return _long; }
            set
            {
                if(value.Length > 15)
                {
                    value = value.Substring(0, 15);
                }
                _long = value;
            }
        }

        /// <summary>
        /// Gets or Sets the value of the latitude
        /// </summary>
        public string Latitude
        {
            get { return _lat; }
            set
            {
                if (value.Length > 15)
                {
                    value = value.Substring(0, 15);
                }
                _lat = value;
            }
        }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Default Constructor of Poi class
        /// </summary>
        public Poi()
        {

        }

        public Poi(int id, string longitude, string latitude, int idCat)
        {
            Id = id;
            Longitude = longitude;
            Latitude = latitude;
            idCategory = idCat;
        }
        #endregion 
    }
}