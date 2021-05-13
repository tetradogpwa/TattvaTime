using Innovative.SolarCalculator;
using System;

namespace TattvaTime
{
    public class Tattva
    {
        const int MILISEGUNDOS_MINUTO = 60 * 1000;
        const int MINUTOS_DOS_HORAS = 2 * 60;
        const int MINUTOS_MEDIO_DIA = MINUTOS_DOS_HORAS * 6;
        const int DOS_HORAS = MINUTOS_DOS_HORAS * MILISEGUNDOS_MINUTO;
        const int TOTAL_TATTVAS = 5;
        const int CICLO_TATTVA = MINUTOS_DOS_HORAS / TOTAL_TATTVAS;
        static double MinutosSubTattva { get; set; } = (CICLO_TATTVA * 1.0) / TOTAL_TATTVAS;

        public static long CicloSubTattva { get; private set; } = TimeSpan.FromMinutes(MinutosSubTattva).Ticks;


        public static string[] TattvaNames { get; private set; } = { "Akasha", "Vayu", "Tejas", "Apas", "Prithivi" };
        public static string[] TattvaColors { get; private set; } = { "Gray", "Blue", "Red", "Violet", "Gold" };

        public int TattvaActual { get; private set; }
        public int SubTattvaActual { get; private set; }
        public long NextSubTattvaTicks { get; private set; }

        public string TattvaColor => TattvaColors[TattvaActual];
        public string SubTattvaColor => TattvaColors[SubTattvaActual];
        public string TattvaName => TattvaNames[TattvaActual];
        public string SubTattvaName => TattvaNames[SubTattvaActual];

        public DateTime Sunrise { get; private set; }

        public DateTime Time { get; set; }
        public double Longitud { get; private set; }
        public double Latitud { get; private set; }

        int TotalMinutosSunrise => Sunrise.TotalMinutes();
        DateTime InitTime { get; set; }

        public Tattva(DateTime initTime, double latitude, double longitude)
        {

            Time = initTime;
            Latitud = latitude;
            Longitud = longitude;
            UpdateSunrise();
            InitTime = DateTime.Now;
              NextSubTattvaTicks= Update();
        }

        private void UpdateSunrise()
        {
            Sunrise = new SolarTimes(Time.Date, Latitud, Longitud).Sunrise;
        }

        public long Update(DateTime horaDespues = default)
        {
            TimeSpan diferencia;
            int totalMinutosRelativos;
            int diferenciaMinutos;
            int minutosRelativos;
            if (Equals(horaDespues, default))
            {
                //quiere la direfencia con la hora real
                diferencia = DateTime.Now - InitTime;

            }
            else
            {
                diferencia = horaDespues - Time;
            }
            Time = Time + TimeSpan.FromMinutes(diferencia.TotalMinutes());
            totalMinutosRelativos = Time.TotalMinutes();

            UpdateSunrise();
            diferenciaMinutos = totalMinutosRelativos - TotalMinutosSunrise;
            if (diferenciaMinutos < 0)
            {
                //quiere decir que es la madrugada del dia siguiente
                diferenciaMinutos *= -1;
                minutosRelativos = diferenciaMinutos % MINUTOS_DOS_HORAS;



            }
            else
            {
                //quiere decir que aun no ha llegado a media noche
                minutosRelativos = diferenciaMinutos % MINUTOS_DOS_HORAS;

            }

            TattvaActual = minutosRelativos / CICLO_TATTVA;

            if (diferenciaMinutos < 0)
                TattvaActual = TOTAL_TATTVAS - TattvaActual;

            SubTattvaActual = ((int)((minutosRelativos % CICLO_TATTVA) / MinutosSubTattva)) % TOTAL_TATTVAS;
            NextSubTattvaTicks= ((int)((minutosRelativos % CICLO_TATTVA) % MinutosSubTattva))*60*1000;
            return NextSubTattvaTicks;

        }
    
    }
}
