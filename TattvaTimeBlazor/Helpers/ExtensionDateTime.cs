using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TattvaTimeBlazor.Helpers
{
    public static class ExtensionDateTime
    {
        public static int TotalMinutes(this DateTime time) => (time.Hour * 60) + time.Minute;
    }
}
