using gestion_salle_de_classe.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_salle_de_classe_tests
{
    public class DemandeMock : Demande
    {
        public override string DemandeCode(string question)
        {
            string res;
            if (question == "Code :")
            {
                res = "A1";
            }
            else
            {
                res = "erreur";
            }
            return res;
        }
        public override string DemandeString(string question)
        {
            string res;
            if (question == "Nom :")
            {
                res = "nom";
            }
            else if (question == "Adresse :")
            {
                res = "adr";
            }
            else if (question == "Type :")
            {
                res = "typ";
            }
            else if (question == "Entrez le nom du batiment de la classe :")
            {
                res = "nom";
            }
            else if (question == "Ville :")
            {
                res = "vil";
            }
            else
            {
                res = "erreur";
            }
            return res;
        }
        public override int DemandeInt(string question)
        {
            int res;
            if (question == "Code Postal :")
            {
                res = 123;
            }
            else
            {
                res = 10000;
            }
            return res;
        }
    }
}
