namespace gestion_salle_de_classe.Services
{
    public class Demande
    {
        public virtual string DemandeString(string affichage)
        {
            Console.WriteLine(affichage);
            return Console.ReadLine()!;
        }
        public virtual string DemandeCode(string affichage)
        {
            string code = "";
            while (true)
            {
                Console.WriteLine(affichage);
                code = Console.ReadLine()!;
                // on vérifie que le code n'est pas vide pour afficher le message d'erreur
                // et éviter une erreur lors de la comparaison de la première lettre
                if (code == "")
                {
                    Console.WriteLine("Saisie Incorrecte : le code de la salle ne doit pas être vide");
                }
                else if (code[0] != char.ToLower(code[0]))
                {
                    break;
                }
                else if (code.All(char.IsDigit))
                {
                    Console.WriteLine("Saisie Incorrecte : le code de la salle ne doit pas être un numérique");
                }
                else
                {
                    Console.WriteLine("Saisie Incorrecte : le code de la salle doit commencer par une majuscule");
                }
            }
            return code;
        }
        public virtual int DemandeInt(string affichage)
        {
            int nbr = 0;
            while (nbr <= 0)
            {
                Console.WriteLine(affichage);
                // la valeur par défaut de nbr en cas d'échec est 0, donc il suffit de vérifier que
                // nbr est inférieur ou égal à 0 pour savoir si la conversion a échoué mais pour
                // afficher un message plus précis on vérifie quand même si la conversion a échoué
                if (!int.TryParse(Console.ReadLine()!, out nbr))
                {
                    affichage = "Saisie incorrecte : entrez un entier";
                }
                else if (nbr <= 0)
                {
                    affichage = "Saisie incorrecte : l'entier doit être strictement supérieur à 0";
                }
            }
            return nbr;
        }
    }
}
