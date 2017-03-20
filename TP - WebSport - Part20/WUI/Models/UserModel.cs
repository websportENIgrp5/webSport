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
    public class UserModel
    {
        public int Id { get; set; }

        public String Login { get; set; }
    }
}