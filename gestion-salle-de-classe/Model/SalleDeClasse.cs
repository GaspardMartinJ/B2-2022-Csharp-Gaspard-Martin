using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace gestion_salle_de_classe.Model
{
    public class SalleDeClasse
    {
        //créer une matiere contenant : code, libellé, nombre d'heures, niveau (B1, B2, B3...)
        public string Code { get; set; }
        public string Type { get; set; }
        public int NbPlaces { get; set; }
    }
}
