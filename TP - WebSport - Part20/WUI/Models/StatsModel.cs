﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WUI.Models
{
    public class StatsModel
    {
        public int IdCourse { get; set; }

        public string Title { get; set; }

        public int Distance { get; set; }

        public Nullable<TimeSpan> Time { get; set; }

        public Nullable<TimeSpan> FastestTime { get; set; }

        public string Category { get; set; }

        public double MySpeed { get; set; }

        public double AverageSpeed { get; set; }

        public double FastestSpeed { get; set; }
    }
}