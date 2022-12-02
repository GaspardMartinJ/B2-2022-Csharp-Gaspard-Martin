using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestion_salle_de_classe.Model;

namespace gestion_salle_de_classe.Services
{
    public class SalleDeClasseServices
    {
        Demande demande = new Demande();
        private List<SalleDeClasse> salleDeClasses = new();
        public void AjouterSalleDeClasse()
        {
            bool dejaDef = false;
            SalleDeClasse salleDeClasse = CreerSalleDeClasse();
            foreach (SalleDeClasse testSalleDeClasse in salleDeClasses)
            {
                if (testSalleDeClasse.Code == salleDeClasse.Code)
                {
                    Console.WriteLine("Une salle de classe avec le même code a déja été définie.");
                    dejaDef = true;
                }
            }
            if (!dejaDef)
            {
                salleDeClasses.Add(salleDeClasse);
            }

        }
        public SalleDeClasse CreerSalleDeClasse()
        {
            SalleDeClasse salleDeClasse = new()
            {
                Code = demande.DemandeCode("Code :"),
                Type = demande.DemandeString("Type :"),
                NbPlaces = demande.DemandeInt("Nombre de places :"),
            };
            return salleDeClasse;
        }
        public string AfficherSallesDeClasse()
        {
            List<string> affichage = new();
            if (salleDeClasses.Count > 0)
            {
                foreach (SalleDeClasse salleDeClasse in salleDeClasses)
                {
                    affichage.Add(AfficherSalleDeClasse(salleDeClasse));
                }
            }
            else
            {
                Console.WriteLine("Aucune salle de classe n'est définie.");
            }
            return string.Join("\n", affichage);
        }
        public string AfficherNbPlaceTotal()
        {
            int total = 0;
            foreach (SalleDeClasse salleDeClasse in salleDeClasses)
            {
                total += salleDeClasse.NbPlaces;
            }
            CultureInfo culture = CultureInfo.CreateSpecificCulture("de-DE");
            string formatted = "Nombre total de places:" + total.ToString("N3", culture);
            return formatted;
        }
            public string AfficherSalleDeClasse(SalleDeClasse salleDeClasse)
        {
            string padding = new('-', 36);
            CultureInfo culture = CultureInfo.CreateSpecificCulture("de-DE");
            string formatted = salleDeClasse.NbPlaces.ToString("N3", culture);
            return $"{padding}\nCode : {salleDeClasse.Code}, Type : {salleDeClasse.Type}\nNombre de places : {formatted}\n{padding}";
        }
    }
}
