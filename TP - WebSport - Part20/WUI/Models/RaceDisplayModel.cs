using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WUI.Models
{
    public class RaceDisplayModel
    {
        public string Title { get; set; }

        public int Distance { get; set; }

        public string City { get; set; }

        public Nullable<TimeSpan> Time { get; set; }

        public int? Classement { get; set; }

        public string State { get; set; }

        public DateTime Date { get; set; }
    }
}