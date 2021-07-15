using Innovative.SolarCalculator;
using System;

namespace TattvaTime
{
    public class Tattva
    {
        const int SEGUNDOS_DOS_HORAS = 2 * 60*60;
        const int TOTAL_TATTVAS = 5;
        public const int CICLO_TATTVA = SEGUNDOS_DOS_HORAS / TOTAL_TATTVAS;
        public const int CICLO_SUBTATTVA =(int)((CICLO_TATTVA * 1.0 / TOTAL_TATTVAS));

        public enum Name
        {
            Akasha, Vayu, Tejas, Apas, Prithivi 
        }
        public static string[] TattvaColors { get; private set; } = { "Gray", "Blue", "Red", "Violet", "Gold" };

        public int TattvaActual { get; private set; }
        public int SubTattvaActual { get; private set; }
        public long NextSubTattvaTicks { get; private set; }

        public string TattvaColor => TattvaColors[TattvaActual];
        public string SubTattvaColor => TattvaColors[SubTattvaActual];
        public Name TattvaName =>(Name) TattvaActual;
        public Name SubTattvaName =>(Name)SubTattvaActual;

        public DateTime Sunrise { get; private set; }

        public DateTime Time { get; set; }
        public double Longitud { get; private set; }
        public double Latitud { get; private set; }

        int TotalSegundosSunrise => Sunrise.TotalSeconds();
        DateTime InitTime { get; set; }

        public Tattva(DateTime initTime, double latitude, double longitude)
        {

            Time = initTime;
            Latitud = latitude;
            Longitud = longitude;
            UpdateSunrise();
            InitTime = DateTime.Now;
            NextSubTattvaTicks = Update();
        }

        private void UpdateSunrise()
        {
            Sunrise = new SolarTimes(Time.Date, Latitud, Longitud).Sunrise;
        }

        public long Update(DateTime horaDespues = default(DateTime))
        {
            TimeSpan diferencia;
            int totalSegundosRelativos;
            int diferenciaSegundos;
            int segundosRelativos;
            int segundosSubTattva;
            if (Equals(horaDespues, default(DateTime)))
            {
                //quiere la direfencia con la hora real
                diferencia = DateTime.Now - InitTime;

            }
            else
            {
                diferencia = horaDespues - Time;
            }
            Time = Time + TimeSpan.FromSeconds(diferencia.TotalSeconds());
            totalSegundosRelativos = Time.TotalSeconds();

            UpdateSunrise();
            diferenciaSegundos = totalSegundosRelativos - TotalSegundosSunrise;
            if (diferenciaSegundos < 0)
            {//esta mal el tattva y el subTattva cuando cambia de dia
                //quiere decir que es la madrugada del dia siguiente
                //diferenciaSegundos *= -1;
                //segundosRelativos = diferenciaSegundos % SEGUNDOS_DOS_HORAS;
                //TattvaActual =TOTAL_TATTVAS -1 - (segundosRelativos / CICLO_TATTVA);


                segundosRelativos = (diferenciaSegundos*-1) % SEGUNDOS_DOS_HORAS;
                TattvaActual = segundosRelativos / CICLO_TATTVA;

            }
            else
            {
                //quiere decir que aun no ha llegado a media noche
                segundosRelativos = diferenciaSegundos % SEGUNDOS_DOS_HORAS;
                TattvaActual = segundosRelativos / CICLO_TATTVA;

            }

            segundosSubTattva = ((int)((segundosRelativos % CICLO_TATTVA) / CICLO_SUBTATTVA));
            SubTattvaActual = segundosSubTattva % TOTAL_TATTVAS;
            NextSubTattvaTicks = segundosSubTattva * 1000;
            return NextSubTattvaTicks;

        }

    }
}
