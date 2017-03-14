﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public enum UnitDistance
    {
        Kilometers = 0,
        Miles = 1
    }

    public enum DbServer
    {
        [Description("SQL")]
        SQL,
        [Description("POSTGRESQL")]
        POSTGRESQL,
        [Description("ORACLE")]
        ORACLE,
        // etc...
    }

    public static class Enums
    {
        public static string GetDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
