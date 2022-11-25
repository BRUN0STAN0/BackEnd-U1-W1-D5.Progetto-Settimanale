using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_settimanale
{
    internal class Contribuente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public string CodiceFiscale { get; set; }
        public string Sesso { get; set; }
        public string ComuneResidenza { get; set; }
        public double RedditoAnnuale { get; set; }
        public double Imposta;
        public double RedditoAnnualeNetto;

        public double CalcolaAliquota()
        {
            if (RedditoAnnuale < 15000)
            {
                Imposta = RedditoAnnuale * 23 / 100;
            } else if (RedditoAnnuale < 28000)
            {
                Imposta = 3450 + ((RedditoAnnuale - 15000) * 27 / 100);
            } else if (RedditoAnnuale < 55000)
            {
                Imposta = 6960 + ((RedditoAnnuale - 28000) * 38 / 100);
            } else if (RedditoAnnuale < 75000)
            {
                Imposta = 17220 + ((RedditoAnnuale - 55000) * 41 / 100);
            } else if (RedditoAnnuale > 75000)
            {
                Imposta = 25420 + ((RedditoAnnuale - 75900) * 43 / 100);
            } else
            {
                Console.WriteLine("Reddito annuale non inserito. Riprova ad inserire");
                Console.WriteLine("il tuo reddito annuale per effettuare il calcolo.");
                SportelloAgenziaEntrate.Benvenuto();
            }
            return RedditoAnnualeNetto = RedditoAnnuale - Imposta;
        }
    }
}
