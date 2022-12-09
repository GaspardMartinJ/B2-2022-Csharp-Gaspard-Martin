using gestion_salle_de_classe.Services;
using gestion_salle_de_classe.Model;
internal class Program
{
    private static void Main(string[] args)
    {
        Demande demande = new();
        BatimentServices batimentServices = new(demande);
        SalleDeClasseServices salleDeClasseServices = new(demande, batimentServices);
        bool boucle = true;
        while (boucle)
        {
            string input = demande.DemandeString(
                "Bienvenue dans l'application de gestion de salles\n" +
                "Que voulez vous faire ?\n" +
                "1. Créer une nouvelle salle\n" +
                "2. Afficher l'ensemble des salles\n" +
                "3. Afficher le nombre total de places\n" +
                "4. Créer un nouveau batiment\n" +
                "5. Afficher l'ensemble des batiments\n" +
                "Q. Quitter").ToLower();
            switch (input)
            {
                case "1":
                    salleDeClasseServices.AjouterSalleDeClasse(salleDeClasseServices.CreerSalleDeClasse());
                    break;
                case "2":
                    Console.WriteLine(salleDeClasseServices.AfficherSallesDeClasse());
                    break;
                case "3":
                    Console.WriteLine(salleDeClasseServices.AfficherNbPlaceTotal());
                    break;
                case "4":
                    batimentServices.AjouterBatiment(batimentServices.CreerBatiment());
                    break;
                case "5":
                    Console.WriteLine(batimentServices.AfficherBatiments());
                    break;
                case "q":
                    boucle = false;
                    break;
                default:
                    break;
            }
        }
    }
}