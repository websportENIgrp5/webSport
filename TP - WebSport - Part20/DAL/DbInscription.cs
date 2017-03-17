using BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EntityFramework;
using DAL.Extensions;

namespace DAL
{
    public class DbInscription
    {
        private static DbInscription _instance;
        public static DbInscription GetInstance()
        {
            if (_instance == null)
                _instance = new DbInscription();
            return _instance;
        }

        private const string RQT_GET_STATS = "select c.Titre, i.Temps, cat.Libelle" + 
                                            "from Inscription i" + 
                                            "inner join Participant p on i.IdParticipant = p.PersonneId" + 
                                            "inner join Personne per on p.PersonneId = per.Id" + 
                                            "inner join UserTable u on p.IdUser = u.Id" + 
                                            "inner join Course c on i.IdCourse = c.Id" + 
                                            "inner join CategorieCourse cat on c.IdCategorieCourse = cat.Id" + 
                                            "where u.Id = 1;";
 
        private EntityFramework.Inscription BuildInscription(DbDataReader reader)
        {
            // On lit la première ligne
            var result = reader.Read();

            EntityFramework.Inscription r = null;
            if (result)
            {
                // On construit l'objet
                r = new EntityFramework.Inscription
                {
                    Id = reader.GetInt32(reader.GetOrdinal("IId")),
                    IdParticipant = reader.GetInt32(reader.GetOrdinal("IIdParticipant")),
                    IdCourse = reader.GetInt32(reader.GetOrdinal("IIdCourse")),
                    IdSuiviInscription = reader.GetInt32(reader.GetOrdinal("IIdSuiviDescription")),
                    NumClassement = reader.GetInt32(reader.GetOrdinal("INumClassement")),
                    Temps = reader.GetString(reader.GetOrdinal("ITemps"))
                };
            }

            return r;
        }
    }
}
