
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
        public void TestAjouterSalleDeClasse()
        {
            salleDeClasseServices.AjouterSalleDeClasse(salleDeClasseServices.CreerSalleDeClasse());
            SalleDeClasse s = salleDeClasseServices.sallesDeClasse[0];

            Assert.IsNotNull(s);
            Assert.That(s.Code, Is.EqualTo("A1"));
            Assert.That(s.Type, Is.EqualTo("typ"));
            Assert.That(s.NbPlaces, Is.EqualTo(10000));
            Assert.That(s.Batiment, Is.EqualTo(batimentServices.batiments[0]));
        }

        [Test]
        public void TestAfficherSalleDeClasse()
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
        public void TestAfficherSalleDeClasses()
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