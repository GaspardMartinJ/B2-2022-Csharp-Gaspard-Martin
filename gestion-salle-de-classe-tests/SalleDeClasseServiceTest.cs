
using gestion_salle_de_classe.Model;
using gestion_salle_de_classe.Services;

namespace gestion_salle_de_classe_tests
{
    public class SalleDeClasseServicesTests
    {
        private BatimentServices batimentServices;
        private SalleDeClasseServices salleDeClasseServices;
        private DemandeMock demandeMock;
        [SetUp]
        public void Setup()
        {
            demandeMock = new DemandeMock();
            batimentServices = new(demandeMock);
            batimentServices.batiments.Add(batimentServices.CreerBatiment());
            salleDeClasseServices = new(demandeMock, batimentServices);
        }

        [Test]
        public void TestCreerSalleDeClasse()
        {
            SalleDeClasse s = salleDeClasseServices.CreerSalleDeClasse();

            Assert.IsNotNull(s);
            Assert.That(s.Code, Is.EqualTo("A1"));
            Assert.That(s.Type, Is.EqualTo("typ"));
            Assert.That(s.NbPlaces, Is.EqualTo(10000));
            Assert.That(s.Batiment, Is.EqualTo(batimentServices.batiments[0]));
        }

        [Test]
        public void TestDemandeBatiment()
        {
            Batiment b = salleDeClasseServices.DemandeBatiment();

            Assert.IsNotNull(b);
            Assert.That(b.Code, Is.EqualTo("A1"));
            Assert.That(b.Nom, Is.EqualTo("nom"));
            Assert.That(b.Adresse, Is.EqualTo("adr"));
            Assert.That(b.CodePostal, Is.EqualTo(123));
            Assert.That(b.Ville, Is.EqualTo("vil"));
            Assert.That(b.SalleDeClasses, Is.EqualTo(new List<SalleDeClasse>()));
        }
        public void TestAfficherBatiment()
        {
            SalleDeClasse s = salleDeClasseServices.CreerSalleDeClasse();
            string res = salleDeClasseServices.AfficherSalleDeClasse(s);

            Assert.IsNotNull(res);
            Assert.That(res, Is.EqualTo(
                "------------------------------------\n" +
                "Code : A1, Type : typ\n" +
                "Nombre de places : 10.000\n" +
                "Batiment : nom, Ville : vil\n" +
                "------------------------------------"));
        }

        [Test]
        public void TestAfficherBatiments()
        {
            salleDeClasseServices.AjouterSalleDeClasse(salleDeClasseServices.CreerSalleDeClasse());
            salleDeClasseServices.AjouterSalleDeClasse(salleDeClasseServices.CreerSalleDeClasse());
            string res = salleDeClasseServices.AfficherSallesDeClasse();

            Assert.IsNotNull(res);
            Assert.That(res, Is.EqualTo(
                "------------------------------------\n" +
                "Code : A1, Type : typ\n" +
                "Nombre de places : 10.000\n" +
                "Batiment : nom, Ville : vil\n" +
                "------------------------------------\n" +
                "------------------------------------\n" +
                "Code : A1, Type : typ\n" +
                "Nombre de places : 10.000\n" +
                "Batiment : nom, Ville : vil\n" +
                "------------------------------------"));
        }

        [Test]
        public void TestAfficherNbPlaceTotal()
        {
            salleDeClasseServices.AjouterSalleDeClasse(salleDeClasseServices.CreerSalleDeClasse());
            string res = salleDeClasseServices.AfficherNbPlaceTotal();

            Assert.IsNotNull(res);
            Assert.That(res, Is.EqualTo(
                "------------------------------------\n" +
                "Nombre total de places: 10.000\n" +
                "------------------------------------"));
        }
    }
}