using System.Globalization;
using gestion_salle_de_classe.Model;

namespace gestion_salle_de_classe.Services
{
    public class SalleDeClasseServices
    {
        Demande demande = new();
        private List<SalleDeClasse> sallesDeClasse = new();
        // le format numérique allemand a des points entre les milliers
        CultureInfo format = CultureInfo.CreateSpecificCulture("de-DE");

        // on sépare la création d'une salle en 2 au cas où on voudrait
        // utiliser seulement une des 2 fonctionnalités
        public void AjouterSalleDeClasse(SalleDeClasse salleDeClasse)
        {
            sallesDeClasse.Add(salleDeClasse);
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
            foreach (SalleDeClasse salleDeClasse in sallesDeClasse)
            {
                affichage.Add(AfficherSalleDeClasse(salleDeClasse));
            }
            return string.Join("\n", affichage);

        }
        public string AfficherSalleDeClasse(SalleDeClasse salleDeClasse)
        {
            string padding = new('-', 36);
            // on formatte l'entier, le 0 du N0 précise le nombre de chiffre
            // après la virgule a afficher
            string formatted = salleDeClasse.NbPlaces.ToString("N0", format);
            return $"{padding}\n" +
                $"Code : {salleDeClasse.Code}, Type : {salleDeClasse.Type}\n" +
                $"Nombre de places : {formatted}\n" +
                padding;
        }
        public string AfficherNbPlaceTotal()
        {
            int total = 0;
            foreach (SalleDeClasse salleDeClasse in sallesDeClasse)
            {
                total += salleDeClasse.NbPlaces;
            }
            string padding = new('-', 36);
            return $"{padding}\nNombre total de places: {total.ToString("N0", format)}\n{padding}";
        }
    }
}
