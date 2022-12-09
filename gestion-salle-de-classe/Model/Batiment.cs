using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_salle_de_classe.Model
{
    public class Batiment
    {
        public string Code { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public int CodePostal { get; set; }
        public string Ville { get; set; }
        public List<SalleDeClasse> SalleDeClasses { get; set; }
    }
}
