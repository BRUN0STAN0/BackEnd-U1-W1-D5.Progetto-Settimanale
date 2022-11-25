using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_settimanale
{
    internal static class SportelloAgenziaEntrate
    {
        public static void Benvenuto()
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("A G E N Z I A  D E L L E  E N T R A T E");
            Console.WriteLine("=======================================\n");
            Console.WriteLine("* Benvenuto allo sportello, vuoi registrarti? y/n");
            string sceltaRegistrazione = Console.ReadLine();
            if (sceltaRegistrazione == "y") Registrazione();
            else { Console.WriteLine("Arrivederci, premi un tasto per chiudere lo sportello."); Console.ReadLine(); }
        }

        private static void Registrazione()
        {
            Console.WriteLine("... stai per registrarti come contribuente, premi un tasto per confermare.");
            Contribuente newContribuente = new Contribuente();
            Console.ReadLine();
            Console.WriteLine("* Si prega di inserire il nome: ");
            newContribuente.Nome = Console.ReadLine();
            Console.WriteLine("* Si prega di inserire il cognome: ");
            newContribuente.Cognome = Console.ReadLine();
            int anno;
        annoCatch:
            Console.WriteLine("* Si prega di inserire l'anno di nascita: ");
            try
            {
                anno = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("! ERRORE: carattere invalido. Reinserire il mese di nascita in numeri: \n");
                goto annoCatch;
            }
            int mese;
        meseCatch:
            Console.WriteLine("* Si prega di inserire il mese di nascita in numeri valido: ");
            do
            {
                try
                {
                    mese = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("! ERRORE: carattere invalido. Reinserire il mese di nascita in numeri: \n");
                    goto meseCatch;
                }
            } while (mese > 12);
            int giorno;
        giornoCatch:
            Console.WriteLine("* Si prega di inserire il giorno di nascita: ");
            do
            {
                try
                {
                    giorno = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("! ERRORE: carattere invalido. Reinserire il mese di nascita in numeri:\n");
                    goto giornoCatch;
                }
            } while (giorno > 31);
            try
            {
                newContribuente.DataNascita = new DateTime(anno, mese, giorno);
            }
            catch
            {
                Console.WriteLine("! ERRORE: DATA INVALIDA. Recompilare i seguenti campi perfavore: \n ");
                goto annoCatch;
            }
            Console.WriteLine("* Si prega di inserire il Codice Fiscale: ");
            newContribuente.CodiceFiscale = Console.ReadLine();
            Console.WriteLine("* Si prega di inserire il Sesso: ");
            newContribuente.Sesso = Console.ReadLine();
            Console.WriteLine("* Si prega di inserire il Comune di Residenza: ");
            newContribuente.ComuneResidenza = Console.ReadLine();
        RedditoAnnualeCatch:
            Console.WriteLine("* Si prega di inserire il Reddito Annuale: ");
            try
            {
                newContribuente.RedditoAnnuale = double.Parse(Console.ReadLine());
            } catch
            {
                Console.WriteLine("! ERRORE: Inserire un numero valido. ( CARATTERE INVALIDO ) ");
                Console.WriteLine("CONSIGLIO: Utilizzare il punto al posto della virgola.\n ");
                goto RedditoAnnualeCatch;
            }
            Console.WriteLine("==============================================");
            Console.WriteLine("R E G I S T R A Z I O N E  E F F E T T U A T A");
            Console.WriteLine("==============================================\n");
            CalcolaRedditoNetto(newContribuente);
            
        }

        public static void CalcolaRedditoNetto(Contribuente contribuente)
        {
            Console.WriteLine("Vorresti calcolare il tuo Reddito Netto? Y/n");
            string calcolareRedditoNetto = Console.ReadLine();
            if (calcolareRedditoNetto == "y") contribuente.CalcolaAliquota();
            else { Console.WriteLine("Arrivederci, premi un tasto per chiudere lo sportello."); Console.ReadLine(); }
            Console.WriteLine("===============================================");
            Console.WriteLine("C A L C O L O  I M P O S T A  D A  V E R S A R E");
            Console.WriteLine("===============================================\n");
            Console.WriteLine($"Contribuente: {contribuente.Nome} {contribuente.Cognome}");
            Console.WriteLine($"Nato il: {contribuente.DataNascita.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Residente in: {contribuente.ComuneResidenza}");
            Console.WriteLine($"Codice Fiscale: {contribuente.CodiceFiscale}\n");
            Console.WriteLine($"Reddito Lordo Dichiarato: {contribuente.RedditoAnnuale}");
            Console.WriteLine($"Reddito Netto: {contribuente.RedditoAnnualeNetto}\n");
            Console.WriteLine($"IMPOSTA DA VERSARE: {contribuente.Imposta}");
            Console.ReadLine();
        }
    }
}
