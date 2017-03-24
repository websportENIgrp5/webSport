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

        private const string RQT_GET_STATS = "select c.Titre, i.Temps, c.Distance, cat.Libelle, c.Id " + 
                                            "from Inscription i " + 
                                            "inner join Participant p on i.IdParticipant = p.PersonneId " + 
                                            "inner join Personne per on p.PersonneId = per.Id " + 
                                            "inner join UserTable u on p.IdUser = u.Id " + 
                                            "inner join Course c on i.IdCourse = c.Id " + 
                                            "inner join SuiviInscription s on i.IdSuiviInscription = s.Id " +
                                            "inner join CategorieCourse cat on c.IdCategorieCourse = cat.Id " +
                                            "where u.Id = @idParticipant " +
                                            "and cat.Id = @catId " +
                                            "and s.Id = 7";

        private const string RQT_GET_FASTEST_TIME = "select i.Temps " +
                                            "from Inscription i " +
                                            "inner join Course c on i.IdCourse = c.Id " +
                                            "where i.NumClassement = 1 " +
                                            "and c.Id = @idCourse";

        private const string RQT_GET_AVERAGE_TIME = "select cast(cast(avg(cast(CAST(i.Temps as datetime) as float)) as datetime) as time) TimeResult " +
                                            "from Inscription i " +
                                            "inner join Course c on i.IdCourse = c.Id " +
                                            "where c.Id = @idCourse " +
                                            "and i.IdSuiviInscription = 7";

        private const string RQT_GET_CATEGORY_ID = "select cat.Id " +
                                            "from CategorieCourse cat";

        private const string RQT_GET_LAST_3_INSCRI = "SELECT TOP 3 i.NumClassement, i.Temps, si.Libelle, c.Titre, c.DateStart, c.Ville, c.Distance " +
                                                     "FROM Inscription i " +
                                                     "INNER JOIN SuiviInscription si " +
                                                     "ON i.IdSuiviInscription = si.Id " +
                                                     "INNER JOIN Course c " +
                                                     "ON i.idCourse = c.id " +
                                                     "WHERE i.IdParticipant = @idParticipant ORDER BY i.Id DESC";


        private const string RQT_GET_INSCRI_BY_ID = "SELECT i.Id,  i.NumClassement, i.Temps, si.Libelle, c.Titre, c.DateStart, c.Ville, c.Distance " +
                                                     "FROM Inscription i " +
                                                     "INNER JOIN SuiviInscription si " +
                                                     "ON i.IdSuiviInscription = si.Id " +
                                                     "INNER JOIN Course c " +
                                                     "ON i.idCourse = c.id " +
                                                     "WHERE i.IdParticipant = @idParticipant ORDER BY i.Id DESC";
        private const string RQT_COUNT_INSCRIPTION = "SELECT COUNT(*) FROM Inscription WHERE idCourse = @idCourse";

        private const string RQT_GET_TOTAL_RACE = "SELECT  c.distance, c.IdCategorieCourse, cc.Libelle FROM Inscription i INNER JOIN Course c ON c.Id = i.IdCourse Inner join CategorieCourse cc ON cc.Id = c.IdCategorieCourse WHERE i.IdParticipant=@idParticipant;";

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
        /// Permet de récupérer les statistiques de chaque course du participant, par catégorie.
        /// </summary>
        /// <param name="idParticipant">Contient l'id du participant</param>
        /// <param category="catId">Contient l'id de la catégorie</param>
        /// <returns></returns>
        public List<UserStats> getStatsByCategory(int idParticipant, int catId)
        {
            List<UserStats> listStats = new List<UserStats>();

            var instance = new DbTools();
            var command = instance.CreerRequete(RQT_GET_STATS);

            instance.CreerParametre(command, "@idParticipant", idParticipant);
            instance.CreerParametre(command, "@catId", catId);

            using (DbDataReader reader = command.ExecuteReader())
            {
                listStats = BuildListUserStats(reader);
            }

            if (listStats.Count > 0)
            {
                foreach (UserStats list in listStats)
                {
                    var commandFastestSpeed = instance.CreerRequete(RQT_GET_FASTEST_TIME);
                    instance.CreerParametre(commandFastestSpeed, "@idCourse", list.IdCourse);

                    using (DbDataReader readerFastestSpeed = commandFastestSpeed.ExecuteReader())
                    {
                        list.FastestTime = BuildFastestTime(readerFastestSpeed);
                        if (list.FastestTime != null)
                        {
                            list.FastestSpeed = CalculSpeed(list.Distance, list.FastestTime.Value);
                        }
                    }

                    var commandAverageSpeed = instance.CreerRequete(RQT_GET_AVERAGE_TIME);
                    instance.CreerParametre(commandAverageSpeed, "@idCourse", list.IdCourse);

                    using (DbDataReader readerAverageSpeed = commandAverageSpeed.ExecuteReader())
                    {
                        var averageTime = BuildAverageTime(readerAverageSpeed);
                        if (averageTime != null)
                        {
                            list.AverageSpeed = CalculSpeed(list.Distance, averageTime.Value);
                        }
                    }
                }
            }

            return listStats;
        }

        /// <summary>
        /// Récupère la liste des ids de chaque catégories.
        /// </summary>
        /// <returns></returns>
        public List<int> getCategoriesId()
        {
            List<int> listCategoriesId = new List<int>();

            var instance = new DbTools();
            var command = instance.CreerRequete(RQT_GET_CATEGORY_ID);

            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    listCategoriesId.Add(reader.GetInt32(reader.GetOrdinal("Id")));
                }
            }

            return listCategoriesId;
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
                inscriSuiviRace.Id = reader.GetInt32(reader.GetOrdinal("Id"));
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

        public void Remove(int id)
        {
            DbTools cnx = new DbTools();
            DbCommand command = cnx.CreerRequete("DELETE FROM Inscription WHERE Id= @id;");
            cnx.CreerParametre(command, "@id", id);
            command.ExecuteNonQuery();
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

        /// <summary>
        /// Permet de construire la liste des statistiques de l'utilisateur.
        /// </summary>
        /// <returns></returns>
        public List<UserStats> BuildListUserStats(DbDataReader reader)
        {
            List<UserStats> list = new List<UserStats>();

            while (reader.Read())
            {
                UserStats listStats = new UserStats();
                listStats.IdCourse = reader.GetInt32(reader.GetOrdinal("Id"));
                listStats.Title = reader.GetString(reader.GetOrdinal("Titre"));
                listStats.Distance = reader.GetInt32(reader.GetOrdinal("Distance"));
                listStats.Category = reader.GetString(reader.GetOrdinal("Libelle"));

                // Time
                var time = reader.GetValue(reader.GetOrdinal("Temps"));
                // Nullable
                if (time != DBNull.Value)
                {
                    listStats.Time = DateTimeToTimeSpan(DateTime.ParseExact(time.ToString(), "HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture));
                }

                //string labels = "";
                //double mySpeed = 0;
                //string averageSpeed = "";

                // Labels
                //if (labels != "")
                //{
                //    labels = labels + ", ";
                //}
                //labels = labels + listStats.Title;
                //listStats.Labels = labels;

                // My speed
                if (listStats.IdCourse != 0)
                {
                    listStats.MySpeed = CalculSpeed(listStats.Distance, (TimeSpan)listStats.Time);
                }

                //if (mySpeed != "")
                //{
                //    mySpeed = mySpeed + ", ";
                //}
                //mySpeed = mySpeed + speed;


                list.Add(listStats);
            }

            return list;
        }

        /// <summary>
        /// Récupère le temps le plus rapide de la course.
        /// </summary>
        /// <returns></returns>
        public TimeSpan? BuildFastestTime(DbDataReader readerFastestSpeed)
        {
            Object fastestTimeValue = null;
            TimeSpan? fastestTime = new TimeSpan();

            while (readerFastestSpeed.Read())
            {
                // FastestTime
                fastestTimeValue = readerFastestSpeed.GetValue(readerFastestSpeed.GetOrdinal("Temps"));

            }
            // Nullable
            if (fastestTimeValue != null)
            {
                fastestTime = DateTimeToTimeSpan(DateTime.ParseExact(fastestTimeValue.ToString(), "HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture));
            }
            else
            {
                fastestTime = null;
            }

            return fastestTime;
        }
        
        /// <summary>
        /// Récupère le temps moyen de la course.
        /// </summary>
        /// <returns></returns>
        public TimeSpan? BuildAverageTime(DbDataReader readerAverageSpeed)
        {
            Object averageTimeValue = null;
            TimeSpan? averageTime = new TimeSpan();

            while (readerAverageSpeed.Read())
            {
                // Average time
                averageTimeValue = readerAverageSpeed.GetValue(readerAverageSpeed.GetOrdinal("TimeResult"));

            }

            if (averageTimeValue != null)
            {
                var dfgfd = averageTimeValue.ToString().Substring(0, 8);
                averageTime = DateTimeToTimeSpan(DateTime.ParseExact(dfgfd, "HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture));
            }
            else
        {
                averageTime = null;
            }

            return averageTime;
        }

        /// <summary>
        /// Calcule la vitesse en fonction de la distance et du temps.
        /// </summary>
        /// <returns></returns>
        public double CalculSpeed(int distance, TimeSpan time)
        {
            TimeSpan timeValue = (TimeSpan)time;
            double hours = (double)timeValue.Hours;
            double min = ((double)timeValue.Minutes) / 60;
            double sec = ((double)timeValue.Seconds) / 3660;
            double timeDecimal = hours + min + sec;

            double speed = distance / timeDecimal;

            return speed;
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

        public List<DistanceRaceCategorie> GetDistanceCategoryRaceByIdParticipant(int idParticipant)
        {
            List<DistanceRaceCategorie> distanceByRace = new List<DistanceRaceCategorie>();
            using (DbTools cnx = new DbTools())
            {
                using (DbCommand command = cnx.CreerRequete(RQT_GET_TOTAL_RACE))
                {
                    cnx.CreerParametre(command, "@idParticipant", idParticipant);
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            distanceByRace.Add(new DistanceRaceCategorie
                            {
                                Distance = reader.GetInt32(reader.GetOrdinal("distance")),
                                Categorie = reader.GetInt32(reader.GetOrdinal("IdCategorieCourse")),
                                CategorieString = reader.GetString(reader.GetOrdinal("Libelle")),

                            });
                            
                        }
                    }
                }
                
            }
            return distanceByRace;

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
