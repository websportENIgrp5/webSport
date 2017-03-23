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

        private const string RQT_GET_STATS = "select *" + 
                                            "from Inscription i " + 
                                            "inner join Participant p on i.IdParticipant = p.PersonneId " + 
                                            "inner join Personne per on p.PersonneId = per.Id " + 
                                            "inner join UserTable u on p.IdUser = u.Id " + 
                                            "inner join Course c on i.IdCourse = c.Id " + 
                                            "inner join CategorieCourse cat on c.IdCategorieCourse = cat.Id " +
                                            "where u.Id = @userId " +
                                            "and cat.Id = @catId ";

        private const string RQT_GET_LAST_3_INSCRI = "SELECT TOP 3 i.NumClassement, i.Temps, si.Libelle, c.Titre, c.DateStart, c.Ville, c.Distance " +
                                                     "FROM Inscription i " +
                                                     "INNER JOIN SuiviInscription si " +
                                                     "ON i.IdSuiviInscription = si.Id " +
                                                     "INNER JOIN Course c " +
                                                     "ON i.idCourse = c.id " +
                                                     "WHERE i.IdParticipant = @idParticipant ORDER BY i.Id DESC";


        private const string RQT_GET_INSCRI_BY_ID = "SELECT i.NumClassement, i.Temps, si.Libelle, c.Titre, c.DateStart, c.Ville, c.Distance " +
                                                     "FROM Inscription i " +
                                                     "INNER JOIN SuiviInscription si " +
                                                     "ON i.IdSuiviInscription = si.Id " +
                                                     "INNER JOIN Course c " +
                                                     "ON i.idCourse = c.id " +
                                                     "WHERE i.IdParticipant = @idParticipant ORDER BY i.Id DESC";
        private const string RQT_COUNT_INSCRIPTION = "SELECT COUNT(*) FROM Inscription WHERE idCourse = @idCourse";

        /// <summary>
        /// Permet de récupérer la liste des 3 dernieres inscriptions d'un participant
        /// </summary>
        /// <param name="idParticipant">Contient l'id du participant</param>
        /// <returns></returns>
        public List<InscriRaceSuivi> GetLast3Race(int idParticipant)
        {
            List<InscriRaceSuivi> racesInscri = null;

            //Récuperation de la connexion et création de la commande
            DbTools instance = new DbTools();
            DbCommand command = instance.CreerRequete(RQT_GET_LAST_3_INSCRI);

            //Ajout du parametre idParticipant
            instance.CreerParametre(command, "@idParticipant", idParticipant);

            using (DbDataReader reader = command.ExecuteReader())
            {
               racesInscri = BuildListInscriRaceSuivi(reader);
            }

            return racesInscri;
        }

        /// <summary>
        /// Permet de retourner toutes les courses sur lesquelles un utilisateur est inscrit
        /// </summary>
        /// <param name="idParticipant"></param>
        /// <returns></returns>
        public List<InscriRaceSuivi> GetInscriByIdParticipant(int idParticipant)
        {
            List<InscriRaceSuivi> racesInscri = null;

            //Récuperation de la connexion et création de la commande
            DbTools instance = new DbTools();
            DbCommand command = instance.CreerRequete(RQT_GET_INSCRI_BY_ID);

            //Ajout du parametre idParticipant
            instance.CreerParametre(command, "@idParticipant", idParticipant);

            using (DbDataReader reader = command.ExecuteReader())
            {
                racesInscri = BuildListInscriRaceSuivi(reader);
            }

            return racesInscri;
        }

        /// <summary>
        /// Permet de construire les objets InscriRaceSuivi en fonction de la reponse de la requete
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public List<InscriRaceSuivi> BuildListInscriRaceSuivi(DbDataReader reader)
        {
            List<InscriRaceSuivi> list = new List<InscriRaceSuivi>();

            while (reader.Read())
            {
                InscriRaceSuivi inscriSuiviRace = new InscriRaceSuivi();
                inscriSuiviRace.Title = reader.GetString(reader.GetOrdinal("Titre"));
                inscriSuiviRace.State = reader.GetString(reader.GetOrdinal("Libelle"));
                inscriSuiviRace.Distance = reader.GetInt32(reader.GetOrdinal("Distance"));
                inscriSuiviRace.City = reader.GetString(reader.GetOrdinal("Ville"));
                inscriSuiviRace.Date = reader.GetDateTime(reader.GetOrdinal("DateStart"));

                var test = reader.GetValue(reader.GetOrdinal("Temps"));
                //Champs qui peuvent etre nuls
                if (test != DBNull.Value)
                {
                    inscriSuiviRace.Time = DateTimeToTimeSpan(DateTime.ParseExact(test.ToString(), "HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture));
                }


                var classement = reader.GetValue(reader.GetOrdinal("NumClassement"));
                if (classement != DBNull.Value)
                {
                    inscriSuiviRace.Classement = (Int32)classement;
                }


                list.Add(inscriSuiviRace);
            }
            return list;
        }


        /// <summary>
        /// Permet de retourner le nombre total d'inscri a une course
        /// </summary>
        /// <param name="idCourse"></param>
        /// <returns></returns>
        public int GetCountInscriByCourse(int idCourse)
        {
            int count = 0;
            using (DbTools cnx = new DbTools())
            {
                using (DbCommand command = cnx.CreerRequete(RQT_COUNT_INSCRIPTION))
                {
                    cnx.CreerParametre(command, "@idCourse", idCourse);
                    count = (int)command.ExecuteScalar();
                }
            }
            return count;
        }


        public List<BO.Inscription> getStatsByCategory(int userId, int catId)
        {
            List<BO.Inscription> list = new List<BO.Inscription>();

            var instance = new DbTools();
            var command = instance.CreerRequete(RQT_GET_STATS);

            instance.CreerParametre(command, "@userId", userId);
            instance.CreerParametre(command, "@catId", catId);

            DbDataReader reader = command.ExecuteReader();
            return this.BuildInscriptionList(reader);
        }

        private List<BO.Inscription> BuildInscriptionList(DbDataReader reader)
        {
            List<BO.Inscription> list = new List<BO.Inscription>();

            while (reader.Read())
            {
                var inscriptionId = reader.GetInt32(reader.GetOrdinal("Id"));

                BO.Inscription i;
                if (list.All(x => x.Id != inscriptionId))
                {
                    i = new BO.Inscription
                    {
                        Id = inscriptionId,
                        IdParticipant = reader.GetInt32(reader.GetOrdinal("IdParticipant")),
                        IdCourse = reader.GetInt32(reader.GetOrdinal("IdCourse")),
                        IdSuiviInscription = reader.GetInt32(reader.GetOrdinal("IdSuiviInscription")),
                        NumClassement = reader.GetInt32(reader.GetOrdinal("NumClassement")),
                        Temps = DateTimeToTimeSpan(reader.GetDateTime(reader.GetOrdinal("Temps"))),
                    };
                    list.Add(i);
                }
                else
                {
                    i = list.Single(x => x.Id == inscriptionId);
                }
            }

            return list;
        }

        private TimeSpan DateTimeToTimeSpan(DateTime temps)
        {

            TimeSpan elapsedTime = new TimeSpan(temps.Ticks);
            return elapsedTime;

        }
        //private BO.Inscription BuildInscription(DbDataReader reader)
        //{
        //    // On lit la première ligne
        //    var result = reader.Read();

        //    BO.Inscription r = null;
        //    if (result)
        //    {
        //        // On construit l'objet
        //        r = new BO.Inscription
        //        {
        //            Id = reader.GetInt32(reader.GetOrdinal("Id")),
        //            IdParticipant = reader.GetInt32(reader.GetOrdinal("IdParticipant")),
        //            IdCourse = reader.GetInt32(reader.GetOrdinal("IdCourse")),
        //            IdSuiviInscription = reader.GetInt32(reader.GetOrdinal("IdSuiviDescription")),
        //            NumClassement = reader.GetInt32(reader.GetOrdinal("NumClassement")),
        //            Temps = reader.GetChar(reader.GetOrdinal("Temps"))
        //        };
        //    }

        //    return r;
        //}
    }
}
