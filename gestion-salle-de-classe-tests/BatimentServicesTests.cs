
using gestion_salle_de_classe.Model;
using gestion_salle_de_classe.Services;

namespace gestion_salle_de_classe_tests
{
    public class BatimentServicesTests
    {
        private BatimentServices batimentServices;
        private DemandeMock demandeMock;
        [SetUp]
        public void Setup()
        {
            demandeMock = new DemandeMock();
            batimentServices = new(demandeMock);
        }

        [Test]
        public void TestCreerBatiment()
        {
            Batiment b = batimentServices.CreerBatiment();

            Assert.IsNotNull(b);
            Assert.That(b.Code, Is.EqualTo("A1"));
            Assert.That(b.Nom, Is.EqualTo("nom"));
            Assert.That(b.Adresse, Is.EqualTo("adr"));
            Assert.That(b.CodePostal, Is.EqualTo(123));
            Assert.That(b.Ville, Is.EqualTo("vil"));
            Assert.That(b.SalleDeClasses, Is.EqualTo(new List<SalleDeClasse>()));
        }

        [Test]
        public void TestAfficherBatiment()
        {
            Batiment b = batimentServices.CreerBatiment();
            string res = batimentServices.AfficherBatiment(b);

            Assert.IsNotNull(res);
            Assert.That(res, Is.EqualTo(
                "------------------------------------\n" +
                "Code : A1, Nom : nom\n" +
                "Adresse : adr, Code Postal : 123, Ville : vil\n" +
                "Nombre de places : 0\n" +
                "------------------------------------"));
        }

        [Test]
        public void TestAfficherBatiments()
        {
            batimentServices.batiments.Add(batimentServices.CreerBatiment());
            batimentServices.batiments.Add(batimentServices.CreerBatiment());
            string res = batimentServices.AfficherBatiments();

            Assert.IsNotNull(res);
            Assert.That(res, Is.EqualTo(
                "------------------------------------\n" +
                "Code : A1, Nom : nom\n" +
                "Adresse : adr, Code Postal : 123, Ville : vil\n" +
                "Nombre de places : 0\n" +
                "------------------------------------\n" +
                "------------------------------------\n" +
                "Code : A1, Nom : nom\n" +
                "Adresse : adr, Code Postal : 123, Ville : vil\n" +
                "Nombre de places : 0\n" +
                "------------------------------------"));
        }
    }
}