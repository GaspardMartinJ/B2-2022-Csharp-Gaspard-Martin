using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_salle_de_classe.Services
{
    public class Demande
    {
        public string DemandeString(string affichage)
        {
            Console.WriteLine(affichage);
            return Console.ReadLine()!;
        }
        public string DemandeCode(string affichage)
        {
            string code = "";
            while (true)
            {
                Console.WriteLine(affichage);
                code = Console.ReadLine()!;
                if (code != "")
                {
                    if (code[0] == char.ToLower(code[0]))
                    {
                        if (code.All(char.IsDigit))
                        {
                            Console.WriteLine("Saisie Incorrecte : le code de la salle ne doit pas être un numérique");
                        }
                        else
                        {
                            Console.WriteLine("Saisie Incorrecte : le code de la salle doit commencer par une majuscule");
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Saisie Incorrecte : le code de la salle ne doit pas être vide");
                }
            }
            return code;
        }
        public int DemandeInt(string affichage)
        {
            int nbr = 0;
            while (nbr <= 0)
            {
                Console.WriteLine(affichage);
                int.TryParse(Console.ReadLine()!, out nbr);
            }
            return nbr;
        }
    }
}
