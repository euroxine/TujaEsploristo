using System;
using System.IO;
using Newtonsoft.Json;

namespace TujaEsploristo
{
    class Program
    {
        private const string Nomo = "Tuja Esploristo! Tiu ĉi apo generas Json dosiero el 'tuja vortaro'";

        static void Main(string[] args)
        {
            Console.WriteLine(Nomo);
            if (args.Length == 1 && (args[0].Contains("info") || args[0].Contains("help") || args[0].Contains("-i")) )
            {
                Console.WriteLine("1. Vi devas sendi la dosierujo 'tuja-vortaro-master' kie troviĝas la ESPDIC.");
                Console.WriteLine(@"      elŝutu ĝin el https://github.com/sstangl/tuja-vortaro");
                Console.WriteLine(@"2. Vi devas indiki kion vi volas generi");
                Console.WriteLine(@"2.1  Por krei la dosiero enhanvanta la ESPDDIC : ");
                Console.WriteLine(@"     > ./TujaEsploristo ujo=/Users/mi/Desktop/tuja-vortaro-master krei=espdic");
                Console.WriteLine(@"2.2  Por krei la dosiero enhanvanta la etimoligiojn : ");
                Console.WriteLine(@"     > ./TujaEsploristo ujo=/Users/mi/Desktop/tuja-vortaro-master krei=etimologio");
                Console.WriteLine(@"2.3  por krei la 60.000 dosierojn, kiujn ĉi tiu apo povos uzi : ");
                Console.WriteLine(@"     > ./TujaEsploristo ujo=/Users/mi/Desktop/tuja-vortaro-master krei=utf8xml");
                Console.WriteLine(@"2.4  por krei la dosierojn en json, kiujn enhavonta la vortarojn : ");
                Console.WriteLine(@"     > ./TujaEsploristo ujo=/Users/mi/Desktop/tuja-vortaro-master krei=vortaroj");
                Console.WriteLine(@"2.5  por krei la dosierojn en json, kiujn enhavonta la difinojn kaj la ekzemplojn : ");
                Console.WriteLine(@"     > ./TujaEsploristo ujo=/Users/mi/Desktop/tuja-vortaro-master krei=difinoj");
                Console.WriteLine(@"2.6  Se vi volas plenumi la vortarojn en alia lingvo");
                Console.WriteLine(@"     > ./TujaEsploristo ujo=/Users/mi/Desktop/tuja-vortaro-master krei=eo_fr");
                Console.WriteLine(@"2.7  Se vi havas plenumi la vortarojn en alia lingvo");
                Console.WriteLine(@"     > ./TujaEsploristo ujo=/Users/mi/Desktop/tuja-vortaro-master krei=eo_fr_eo");
                return;
            }
            Console.WriteLine(JsonConvert.SerializeObject(args));
            string path = string.Empty; //Directory.GetCurrentDirectory();
        
            foreach(var arg in args)
            {
                string[] kio = arg.Split('=');
                switch(kio[0])
                {
                    case "ujo":
                        path = kio[1];
                        break;
                }
                if (!string.IsNullOrWhiteSpace(path))
                    break;
            }
            if (string.IsNullOrWhiteSpace(path))
            {
                Console.WriteLine(@"Mi bezonas scii kie troviĝas la dosierujo enhavanta tuja-vortaro-master : ujo=???");
                return;
            }

            //Mi scias kie troviĝas la dosierujo, one povas daŭrigi
            TujaDosierujo tujaDosierujo = new TujaDosierujo(path);

            foreach (var arg in args)
            {
                string[] kio = arg.Split('=');
                if (kio[0].ToLower() == "krei")
                { 
                    switch (kio[1].ToLower())
                    {
                        case "espdic":
                            tujaDosierujo.KreiESPDIC();
                            break;
                        case "etimologio":
                            tujaDosierujo.KreiEtimologioj();
                            break;
                        case "utf8xml":
                            tujaDosierujo.Unikodiĝi();
                            break;
                        case "vortaroj":
                            tujaDosierujo.KreiVortarojn();
                            break;
                        case "difinoj":
                            tujaDosierujo.KreiDifinojn();
                            break;
                        case "eo_fr":
                            tujaDosierujo.ŝlosiliguPorPlenumi();
                            break;
                        case "eo_fr_eo":
                            tujaDosierujo.DeŝlosiliguPorPlenumi();
                            break;
                    }
                }
            }


        }
    }
}
