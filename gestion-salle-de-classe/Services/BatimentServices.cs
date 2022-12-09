using System.Globalization;
using gestion_salle_de_classe.Model;

namespace gestion_salle_de_classe.Services
{
    public class BatimentServices
    {
        Demande _demande;
        public List<Batiment> batiments = new();
        CultureInfo format = CultureInfo.CreateSpecificCulture("de-DE");
        public BatimentServices(Demande demande)
        {
            _demande = demande;
        }

        public void AjouterBatiment(Batiment batiment)
        {
            batiments.Add(batiment);
        }
        public Batiment CreerBatiment()
        {
            Batiment batiment = new()
            {
                Code = _demande.DemandeCode("Code :"),
                Nom = _demande.DemandeString("Nom :"),
                Adresse = _demande.DemandeString("Adresse :"),
                CodePostal = _demande.DemandeInt("Code Postal :"),
                Ville = _demande.DemandeString("Ville :"),
                SalleDeClasses = new List<SalleDeClasse>(),
            };
            return batiment;
        }
        public string AfficherBatiments()
        {
            List<string> affichage = new();
            foreach (Batiment batiment in batiments)
            {
                affichage.Add(AfficherBatiment(batiment));
            }
            return string.Join("\n", affichage);

        }
        public string AfficherBatiment(Batiment batiment)
        {
            string padding = new('-', 36);
            string formatted = "0";
            if (batiment.SalleDeClasses != null)
            {
                formatted = batiment.SalleDeClasses.Sum(salleDeClasse => salleDeClasse.NbPlaces).ToString("N0", format);
            }
            return $"{padding}\n" +
                $"Code : {batiment.Code}, Nom : {batiment.Nom}\n" +
                $"Adresse : {batiment.Adresse}, Code Postal : {batiment.CodePostal}, Ville : {batiment.Ville}\n" +
                $"Nombre de places : {formatted}\n" +
                padding;
        }
    }
}
