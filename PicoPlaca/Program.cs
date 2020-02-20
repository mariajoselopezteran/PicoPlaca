using System;
namespace PicoPlaca
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Pico & Placa Predictor!");

            bool isFinished = false;

            string carPlate = string.Empty;
            string date = string.Empty;
            string time = string.Empty;
            do
            {
                carPlate = ReadCarPlate();
                date = ReadDate();

                if (!PicoPlacaLibrary.PicoPlaca.IsWeekDate(date))
                {
                    Console.WriteLine("Date selected is a weenkend, you can circulate freely");
                    Console.WriteLine("Do you want to set another date?.");
                    isFinished = IsFinished(isFinished);
                }
                else
                {
                    time = ReadTime();

                    bool isAbleToCirculate = PicoPlacaLibrary.PicoPlaca.IsCarAbleToCirculate(carPlate, date,time);

                    if(isAbleToCirculate)
                        Console.WriteLine("Your car with the plate {0} can circulate on {1} at {2}",carPlate,date,time);
                    else
                        Console.WriteLine("Your car with the plate {0} can NOT circulate on {1} at {2}", carPlate, date, time);

                    Console.WriteLine("Do you want to check another date?");
                    isFinished = IsFinished(isFinished);
                }
            } while (!isFinished);


            Console.WriteLine("Thank you! Good bye ");
            Console.ReadLine();

        }

        private static bool IsFinished(bool isFinished)
        {
            Console.WriteLine("Type 0 to exit");
            Console.WriteLine("Type 1 to set another date");
            var action = Console.ReadLine();

            bool isActionValid = true;
            do
            {
                if (action == "1")
                    break;
                else
                {
                    if (action == "0")
                    {
                        isFinished = true;
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid action");
                        isActionValid = false;
                    }
                }

            } while (isActionValid);
            return isFinished;
        }

        public static string ReadDate()
        {
            string date = string.Empty;
            bool isDateValid = false;
            do
            {
                Console.WriteLine("Please enter a valid date in the format " + '"' + "dd/MM/yyyy" + '"');
                date = Console.ReadLine();

                isDateValid = PicoPlacaLibrary.PicoPlaca.IsDateValid(date);

                if (!isDateValid)
                    Console.WriteLine("Date is invalid");

            } while (!isDateValid);

            return date;
        }

        public static string ReadCarPlate()
        {
            var carPlate = string.Empty;
            bool isCarPlateInCorrect = true;
            do
            {
                Console.WriteLine("Please enter a valid the Plate number of your car:");
                carPlate = Console.ReadLine();

                isCarPlateInCorrect = !PicoPlacaLibrary.PicoPlaca.IsCarPlateValid(carPlate);

                if (isCarPlateInCorrect)
                    Console.WriteLine("Car plate is invalid");

            } while (isCarPlateInCorrect);

            return carPlate;
        }

        public static string ReadTime()
        {
            string time = string.Empty;
            bool isTimeValid = false;
            do
            {
                Console.WriteLine("Please enter a valid the time in the format " +  '"' + "hh:mm" + '"');
                time = Console.ReadLine();

                isTimeValid = PicoPlacaLibrary.PicoPlaca.IsTimeValid(time);

                if (!isTimeValid)
                    Console.WriteLine("Date is invalid");

            } while (!isTimeValid);

            return time;
        }
    }
}
