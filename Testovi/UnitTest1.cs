using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prijava;
using System;

namespace Testovi
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Scenarij1()
        {
            Autentifikator autentifikator = new Autentifikator();

            var korisnik = autentifikator.DohvatiKorisnika("pivic");

            Assert.IsNotNull(korisnik);
        }

        [TestMethod]
        public void Scenarij2()
        {
            Autentifikator autentifikator = new Autentifikator();

            var korisnik = autentifikator.DohvatiKorisnika("thorvat");

            Assert.IsNull(korisnik);
        }

        [TestMethod]
        public void Scenarij3()
        {
            Autentifikator autentifikator = new Autentifikator();

            var korisnik = autentifikator.DohvatiKorisnika("pperic");

            Assert.IsNull(korisnik);
        }

        [TestMethod]
        public void Scenarij4()
        {
            Autentifikator autentifikator = new Autentifikator();

            Assert.ThrowsException<IncorrectAuthenticationData>(() => autentifikator.RegistrirajKorisnika("mmijac", "abc123"));
        }

        [TestMethod]
        public void Scenarij5()
        {
            Autentifikator autentifikator = new Autentifikator();

            Assert.ThrowsException<IncorrectAuthenticationData>(() => autentifikator.RegistrirajKorisnika("test", "abc123"));
        }

        [TestMethod]
        public void Scenarij6()
        {
            Autentifikator autentifikator = new Autentifikator();

            autentifikator.RegistrirajKorisnika("pperic", "123456");

            var korisnik = autentifikator.DohvatiKorisnika("pperic");
            Assert.IsTrue(
                korisnik.KorisnickoIme == "pperic",
                korisnik.Lozinka = "123456",
                korisnik.Tip = TipKorisnika.Obicni
            );

        }

        [TestMethod]
        public void Scenarij7()
        {
            Autentifikator autentifikator = new Autentifikator();

            autentifikator.RegistrirajKorisnika("pperic", "123456", TipKorisnika.Gost);

            var korisnik = autentifikator.DohvatiKorisnika("pperic");
            Assert.IsNull(korisnik);
        }

        [TestMethod]
        public void Scenarij8()
        {
            Autentifikator autentifikator = new Autentifikator();

            Assert.ThrowsException<UnauthorizedRegistrationException>(() =>
                autentifikator.RegistrirajKorisnika("pperic", "123456", TipKorisnika.Administrator)
            );
        }

        [TestMethod]
        public void Scenarij9()
        {
            Autentifikator autentifikator = new Autentifikator();
            autentifikator.PrijaviKorisnika("mmijac", "abcde");

            autentifikator.RegistrirajKorisnika("pperic", "123456", TipKorisnika.Administrator);

            var korisnik = autentifikator.DohvatiKorisnika("pperic");
            Assert.IsTrue(
                korisnik.Tip == TipKorisnika.Administrator
            );

        }

        [TestMethod]
        public void Scenarij10()
        {
            Autentifikator autentifikator = new Autentifikator();

            autentifikator.RegistrirajKorisnika("thorvat", "hfdrz");

            var korisnik = autentifikator.DohvatiKorisnika("thorvat");
            Assert.IsTrue(
                korisnik.Aktivan
            );

        }
    }
}
