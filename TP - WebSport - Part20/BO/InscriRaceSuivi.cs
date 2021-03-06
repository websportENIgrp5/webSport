﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class InscriRaceSuivi
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int Distance { get; set; }

        public string City { get; set; }

        public Nullable<TimeSpan> Time { get; set; }

        public int? Classement { get; set; }

        public string State { get; set; }

        public DateTime Date { get; set; }
    }
}
