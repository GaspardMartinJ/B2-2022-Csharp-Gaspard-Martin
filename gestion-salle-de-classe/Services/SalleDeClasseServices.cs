using System.Globalization;
using gestion_salle_de_classe.Model;

namespace gestion_salle_de_classe.Services
{
    public class SalleDeClasseServices
    {
        Demande _demande;
        BatimentServices _batimentServices;
        public List<SalleDeClasse> sallesDeClasse = new();
        public SalleDeClasseServices(Demande demande, BatimentServices batimentServices)
        {
            _batimentServices = batimentServices;
            _demande = demande;
        }
        // le format numérique allemand a des points entre les milliers
        CultureInfo format = CultureInfo.CreateSpecificCulture("de-DE");

        // on sépare la création d'une salle en 2 au cas où on voudrait
        // utiliser seulement une des 2 fonctionnalités
        public void AjouterSalleDeClasse(SalleDeClasse salleDeClasse)
        {
            if (salleDeClasse != null)
            {
                sallesDeClasse.Add(salleDeClasse);
            }
        }
        public SalleDeClasse CreerSalleDeClasse()
        {
            List<Batiment> batiments = _batimentServices.batiments;
            SalleDeClasse? salleDeClasse = null;
            if (batiments.Count > 0)
            {
                salleDeClasse = new()
                {
                    Code = _demande.DemandeCode("Code :"),
                    Type = _demande.DemandeString("Type :"),
                    NbPlaces = _demande.DemandeInt("Nombre de places :"),
                    Batiment = _batimentServices.DemandeBatiment(),
                };
                salleDeClasse.Batiment.SalleDeClasses.Add(salleDeClasse);
            }
            else
            {
                Console.WriteLine("Il faut définir au moins un batiment avant de pouvoir définir une salle.");
            }
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
                $"Batiment : {salleDeClasse.Batiment.Nom}, Ville : {salleDeClasse.Batiment.Ville}\n" +
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
