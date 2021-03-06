﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    /// <summary>
    /// RaceEntity
    /// </summary>
    [Serializable]
    public class Race : IComparable<Race>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateStart { get; set; }

        public string Town { get; set; }

        public int? Distance { get; set; }

        public int? IdDifficulte { get; set; }

        public int? IdCategoryRace { get; set; }

        public Nullable<System.TimeSpan> HeureStart { get; set; }

        public Nullable<System.TimeSpan> HeureEnd { get; set; }

        public String Reglement { get; set; }


        public virtual Difficulte Difficulte { get; set; }

        public virtual CategoryRace CategoryRace { get; set; }

        public virtual List<Competitor> Competitors { get; set; }

        public virtual List<Inscription> Inscriptions { get; set; }

        public int CompareTo(Race otherRace)
        {
            if (otherRace == null)
            {
                return 1;
            }

            return this.DateStart.CompareTo(otherRace.DateStart);
        }
    }
}
