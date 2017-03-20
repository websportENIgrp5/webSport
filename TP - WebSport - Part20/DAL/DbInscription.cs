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
                        Temps = reader.GetChar(reader.GetOrdinal("Temps")),
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
