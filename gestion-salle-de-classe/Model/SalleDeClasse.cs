namespace gestion_salle_de_classe.Model
{
    public class SalleDeClasse
    {
        public string Code { get; set; }
        public string Type { get; set; }
        public int NbPlaces { get; set; }
        public Batiment Batiment { get; set; }
    }
}
