using System;
using System.Collections.Generic;
using System.Text;

namespace TattvaTime
{
    public static class Extension
    {
        public static int TotalSeconds(this TimeSpan time) => (time.Hours * 60*60) + (time.Minutes*60)+time.Seconds;
        public static int TotalSeconds(this DateTime time) => (time.Hour * 60 * 60) + (time.Minute * 60) + time.Second;
    }
}
