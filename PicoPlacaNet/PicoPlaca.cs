using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PicoPlacaLibrary
{
    public class PicoPlaca
    {
        public static bool IsCarPlateValid(string carPlate)
        {
            bool isCarPlateValid = false;
            if (carPlate.Length >= 6 || carPlate.Length < 8)
            {
                int numbers = Regex.Match(carPlate, @"\d+").Value.Length;
                int letters = carPlate.Length - numbers;

                //Verify that ther are 3 letters and 3 or 4 numbers
                if (letters == 3 && (numbers >= 3 || numbers < 5))
                {
                    //First 3 Digits are letters
                    if (Regex.IsMatch(carPlate.Substring(0, 2), @"^[a-zA-Z]+$"))
                        isCarPlateValid = true;

                    //Last Digits are letters
                    if (Regex.IsMatch(carPlate.Substring(3, numbers), @"\d+"))
                        isCarPlateValid = true;
                }
            }
            return isCarPlateValid;
        }

        public static bool IsDateValid(string date)
        {
            bool isDateValid = false;
            if (date.Length == 10)
            {
                DateTime dateValue;
                string dateformat = "dd/MM/yyyy";
                DateTime.TryParseExact(date, dateformat, new CultureInfo("es-Es"), DateTimeStyles.None, out dateValue);

                if (dateValue != DateTime.MinValue)
                    isDateValid = true;
            }


            return isDateValid;
        }

        public static bool IsWeekDate(string date)
        {
            bool isWeekDate = false;
            if (IsDateValid(date))
            {
                var dateValue = DateTime.Parse(date);
                int dayNumberOfWeek = (int)dateValue.DayOfWeek;

                if (dayNumberOfWeek > 0 && dayNumberOfWeek <= 5)
                {
                    isWeekDate = true;
                }

            }
            return isWeekDate;
        }



        public static bool IsTimeValid(string time)
        {
            bool isTimeValid = false;

            if (time.Length == 5)
            {
                if (Regex.IsMatch(time.Substring(0, 2), @"\d+") && time.Substring(2, 1) == ":" && Regex.IsMatch(time.Substring(3, 2), @"\d+"))
                {
                    int hour = int.Parse(time.Substring(0, 2));
                    int minutes = int.Parse(time.Substring(3, 2));
                    if ((hour >= 0 && hour < 25) && (minutes >= 0 && minutes < 61))
                        isTimeValid = true;
                }

            }


            return isTimeValid;
        }

        public static bool IsCarAbleToCirculate(string plate, string date, string time)
        {
            bool isCarAbleToCirculate = true; //can always circulate if not found different
            bool isPlateInASameDay = false; // is the car plate in the same day as established
            bool isInSchedule = false; // is the time in the pico& placa schedule


            if (IsCarPlateValid(plate) && IsDateValid(date) && IsTimeValid(time))// just verify if dates are valid
            {
                //Verify car plate is in the same date
                int day = (int)DateTime.Parse(date).DayOfWeek;
                int plateNumberDay = int.Parse(plate.Substring(plate.Length - 1, 1));
                switch (day)
                {
                    case 1:
                        if (plateNumberDay == 1 || plateNumberDay == 2)
                            isPlateInASameDay = true;
                        break;
                    case 2:
                        if (plateNumberDay == 3 || plateNumberDay == 4)
                            isPlateInASameDay = true;
                        break;
                    case 3:
                        if (plateNumberDay == 5 || plateNumberDay != 6)
                            isPlateInASameDay = true;
                        break;
                    case 4:
                        if (plateNumberDay == 7 || plateNumberDay != 8)
                            isPlateInASameDay = true;
                        break;
                    case 5:
                        if (plateNumberDay == 9 || plateNumberDay != 0)
                            isPlateInASameDay = true;
                        break;
                }

                //Verify Time is not in pico placa schedule
                if (isPlateInASameDay)
                {
                    int hour = int.Parse(time.Substring(0, 2));
                    int minutes = int.Parse(time.Substring(3, 2));
                    TimeSpan currentTime = new TimeSpan(hour, minutes, 0);

                    TimeSpan morningStartTime = new TimeSpan(7, 0, 0);
                    TimeSpan morningEndTime = new TimeSpan(9, 31, 0);

                    TimeSpan eveningStartTime = new TimeSpan(16, 0, 0);
                    TimeSpan eveningEndTime = new TimeSpan(19, 31, 0);


                    if ((currentTime >= morningStartTime && currentTime < morningEndTime) || (currentTime >= eveningStartTime && currentTime < eveningEndTime))
                        isInSchedule = true;

                    isCarAbleToCirculate = !isInSchedule; // if time is in schedule return false
                }
            }
            else
            {
                isCarAbleToCirculate = false;
            }


            return isCarAbleToCirculate;
        }
    }
}

