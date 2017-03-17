﻿using BO;
using DAL;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL
{
    public class MgtInscription
    {
        private static MgtInscription _instance;
        public static MgtInscription GetInstance()
        {
            if (_instance == null)
                _instance = new MgtInscription();
            return _instance;
        }

        private List<Inscription> _listRace;

        //private Comparison<Inscription> _delegueTrier;
        private UnitOfWork _uow { get; set; }

    }
}