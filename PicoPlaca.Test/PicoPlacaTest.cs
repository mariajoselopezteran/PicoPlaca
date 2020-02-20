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

       #region Car Plate
        [Test]
        public void PicoPlaca_WithPlateLength6_ReturnsTrue()
        {
            //Arrange
            string plate = "IBB355";
            bool actual = true;

            //Act
            var output = PicoPlaca.IsCarPlateValid(plate);

            //Assert
            Assert.AreEqual(actual,output);
        }

        [Test]
        public void PicoPlaca_WithPlateLength7_ReturnsTrue()
        {
            //Arrange
            string plate = "IBB3555";
            bool actual = true;

            //Act
            var output = PicoPlaca.IsCarPlateValid(plate);

            //Assert
            Assert.AreEqual(actual, output);
        }

        [Test]
        public void PicoPlaca_WithplateAllNumbers_ReturnsFalse()
        {
            //Assert
            string plate = "3333555";
            bool actual = false;

            //Act
            var output = PicoPlaca.IsCarPlateValid(plate);

            //Arrange
            Assert.AreEqual(actual, output);
        }

        [Test]
        public void PicoPlaca_WithplateAllLetters_ReturnsFalse()
        {
            //Arrange
            string plate = "AAAAAA";
            bool actual = false;

            //Act
            var output = PicoPlaca.IsCarPlateValid(plate);

            //Assert
            Assert.AreEqual(actual, output);
        }

        [Test]
        public void PicoPlaca_WithplateStarts3letters_ReturnsTrue()
        {
            //Arrange
            string plate = "AAA333";
            bool actual = true;

            //Act
            var output = PicoPlaca.IsCarPlateValid(plate);

            //Assert
            Assert.AreEqual(actual, output);
        }

        [Test]
        public void PicoPlaca_WithplateLastDigitsLetters_ReturnsFalse()
        {
            //Arange
            string plate = "AAAAA";
            bool actual = false;

            //Act
            var output = PicoPlaca.IsCarPlateValid(plate);

            //Assert
            Assert.AreEqual(actual, output);
        }

        [Test]
        public void PicoPlaca_WithplateLast3Numbers_ReturnsTrue()
        {
            //Arrange
            string plate = "AAA222";
            bool actual = true;

            //Act
            var output = PicoPlaca.IsCarPlateValid(plate);

            //Assert
            Assert.AreEqual(actual, output);
        }

        [Test]
        public void PicoPlaca_WithplateLast4Numbers_ReturnsTrue()
        {
            //Arrange
            string plate = "AAA2222";
            bool actual = true;

            //Act
            var output = PicoPlaca.IsCarPlateValid(plate);

            //Assert
            Assert.AreEqual(actual, output);
        }
        #endregion

        #region Date and time
        [Test]
        public void PicoPlaca_WithDateCorrectLength_ReturnsTrue()
        {
            //Arrange
            string date = "21/10/2020";
            bool actual = true;

            //Act
            var output = PicoPlaca.IsDateValid(date);

            //Assert
            Assert.AreEqual(actual, output);
        }

        [Test]
        public void PicoPlaca_WithDateIncorrectLength_ReturnsFalse()
        {
            //Arrange
            string date = "2110/2020";
            bool actual = false;

            //Act
            var output = PicoPlaca.IsDateValid(date);

            //Assert
            Assert.AreEqual(actual, output);
        }

        [Test]
        public void PicoPlaca_WithDateIncorrectDate_ReturnsFalse()
        {
            //Arrange
            string date = "1234567890";
            bool actual = false;

            //Act
            var output = PicoPlaca.IsDateValid(date);

            //Assert
            Assert.AreEqual(actual, output);
        }

        [Test]
        public void PicoPlaca_WithDateWeekDay_ReturnsTrue()
        {
            //Arrange
            string date = "27/02/2020";
            bool actual = true;

            //Act
            var output = PicoPlaca.IsWeekDate(date);

            //Assert
            Assert.AreEqual(actual, output);
        }

        [Test]
        public void PicoPlaca_WithDateWeekEndDay_ReturnsFalse()
        {
            //Arrange
            string date = "23/02/2020";
            bool actual = false;

            //Act
            var output = PicoPlaca.IsWeekDate(date);

            //Assert
            Assert.AreEqual(actual, output);
        }

        [Test]
        public void PicoPlaca_WithTimeLength5_ReturnsTrue()
        {
            //Arrange
            string time = "04:00";
            bool actual = true;

            //Act
            var output = PicoPlaca.IsTimeValid(time);

            //Assert
            Assert.AreEqual(actual, output);
        }

        [Test]
        public void PicoPlaca_WithTimeFirst2DigitsNumbers_ReturnsTrue()
        {
            //Arrange
            string time = "04:00";
            bool actual = true;

            //Act
            var output = PicoPlaca.IsTimeValid(time);

            //Assert
            Assert.AreEqual(actual, output);
        }
        [Test]
        public void PicoPlaca_WithTimeFirst2DigitsLetters_ReturnsFalse()
        {
            //Arrange
            string time = "bb:00";
            bool actual = false;

            //Act
            var output = PicoPlaca.IsTimeValid(time);

            //Assert
            Assert.AreEqual(actual, output);
        }
        [Test]
        public void PicoPlaca_WithTimeWithValidTime_ReturnsTrue()
        {
            //Arrange
            string time = "04:00";
            bool actual = true;

            //Act
            var output = PicoPlaca.IsTimeValid(time);

            //Assert
            Assert.AreEqual(actual, output);
        }
        [Test]
        public void PicoPlaca_WithTimeWithInValidTime_ReturnsFalse()
        {
            //Arrange
            string time = "25:00";
            bool actual = false;

            //Act
            var output = PicoPlaca.IsTimeValid(time);

            //Assert
            Assert.AreEqual(actual, output);
        }

        [Test]
        public void PicoPlaca_WithTimeSeparator_ReturnsTrue()
        {
            //Arrange
            string time = "09:00";
            bool actual = true;

            //Act
            var output = PicoPlaca.IsTimeValid(time);

            //Assert
            Assert.AreEqual(actual, output);
        }
        
        [Test]
        public void PicoPlaca_WithInvalidSeparator_ReturnsFalse()
        {
            //Arrange
            string time = "09,00";
            bool actual = false;

            //Act
            var output = PicoPlaca.IsTimeValid(time);

            //Assert
            Assert.AreEqual(actual, output);
        }

        [Test]
        public void PicoPlaca_WithValidMinutes_ReturnsTrue()
        {
            //Arrange
            string time = "09:12";
            bool actual = true;

            //Act
            var output = PicoPlaca.IsTimeValid(time);

            //Assert
            Assert.AreEqual(actual, output);
        }

        [Test]
        public void PicoPlaca_WithLast2DigitsLetter_ReturnsFalse()
        {
            //Arrange
            string time = "09:bb";
            bool actual = false;

            //Act
            var output = PicoPlaca.IsTimeValid(time);

            //Assert
            Assert.AreEqual(actual, output);
        }

        [Test]
        public void PicoPlaca_WithValidInMinutes_ReturnsFalse()
        {
            //Arrange
            string time = "09:70";
            bool actual = false;

            //Act
            var output = PicoPlaca.IsTimeValid(time);

            //Assert
            Assert.AreEqual(actual, output);
        }


        #endregion

        #region Pico Placa
        [Test]
        public void PicoPlaca_WitplateInDifferentDay_ReturnsTrue()
        {
            //Arrange
            string plate = "IBB3555";
            string date = "20/02/2020";
            string time = "08:00";
            bool expexted = true;

            //Act
            bool output = PicoPlaca.IsCarAbleToCirculate(plate, date, time);

            //Assert
            Assert.AreEqual(expexted, output);
        }

        [Test]
        public void PicoPlaca_WitplateInSameDayOutOfSchedule_ReturnsTrue()
        {
            //Arrange
            string plate = "IBB3555";
            string date = "26/02/2020";
            string time = "09:31";
            bool expexted = true;

            //Act
            bool output = PicoPlaca.IsCarAbleToCirculate(plate, date, time);

            //Assert
            Assert.AreEqual(expexted, output);
        }

        [Test]
        public void PicoPlaca_WitplateInSameDayInOfSchedule_ReturnsFalse()
        {
            //Arrange
            string plate = "IBB3555";
            string date = "27/02/2020";
            string time = "09:00";
            bool expexted = false;

            //Act
            bool output = PicoPlaca.IsCarAbleToCirculate(plate, date, time);

            //Assert
            Assert.AreEqual(expexted, output);
        }
        #endregion


    }
}