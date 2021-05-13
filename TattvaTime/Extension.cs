using System;
using System.Collections.Generic;
using System.Text;

namespace TattvaTime
{
    public static class Extension
    {
        public static int TotalMinutes(this TimeSpan time) => (time.Hours * 60) + time.Minutes;
        public static int TotalMinutes(this DateTime time) => (time.Hour * 60) + time.Minute;
    }
}
