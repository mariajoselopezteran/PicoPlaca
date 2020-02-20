using NUnit.Framework;
using PicoPlacaLibrary;

namespace PicoPlacaTest
{
    public class PicoPlacaTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PicoPlaca_WithPlaqueLength6_ReturnsTrue()
        {
            //Assert
            string plaque = "IBB355";
            bool actual = true;

            //Act
            var output = PicoPlaca.IsPlaqueValid(plaque);

            //Arrange
            Assert.AreEqual(actual,output);
        }

        [Test]
        public void PicoPlaca_WithPlaqueLength7_ReturnsTrue()
        {
            //Assert
            string plaque = "IBB3555";
            bool actual = true;

            //Act
            var output = PicoPlaca.IsPlaqueValid(plaque);

            //Arrange
            Assert.AreEqual(actual, output);
        }

        [Test]
        public void PicoPlaca_WithPlaqueAllNumbers_ReturnsFalse()
        {
            //Assert
            string plaque = "3333555";
            bool actual = false;

            //Act
            var output = PicoPlaca.IsPlaqueValid(plaque);

            //Arrange
            Assert.AreEqual(actual, output);
        }

        [Test]
        public void PicoPlaca_WithPlaqueAllLetters_ReturnsFalse()
        {
            //Assert
            string plaque = "AAAAAA";
            bool actual = false;

            //Act
            var output = PicoPlaca.IsPlaqueValid(plaque);

            //Arrange
            Assert.AreEqual(actual, output);
        }

        [Test]
        public void PicoPlaca_WithPlaqueStarts3letters_ReturnsTrue()
        {
            //Assert
            string plaque = "AAA333";
            bool actual = true;

            //Act
            var output = PicoPlaca.IsPlaqueValid(plaque);

            //Arrange
            Assert.AreEqual(actual, output);
        }

        [Test]
        public void PicoPlaca_WithPlaqueLastDigitsLetters_ReturnsFalse()
        {
            //Assert
            string plaque = "AAAAA";
            bool actual = false;

            //Act
            var output = PicoPlaca.IsPlaqueValid(plaque);

            //Arrange
            Assert.AreEqual(actual, output);
        }

        [Test]
        public void PicoPlaca_WithPlaqueLast3Numbers_ReturnsTrue()
        {
            //Assert
            string plaque = "AAA222";
            bool actual = true;

            //Act
            var output = PicoPlaca.IsPlaqueValid(plaque);

            //Arrange
            Assert.AreEqual(actual, output);
        }

        [Test]
        public void PicoPlaca_WithPlaqueLast4Numbers_ReturnsTrue()
        {
            //Assert
            string plaque = "AAA2222";
            bool actual = true;

            //Act
            var output = PicoPlaca.IsPlaqueValid(plaque);

            //Arrange
            Assert.AreEqual(actual, output);
        }
    }
}