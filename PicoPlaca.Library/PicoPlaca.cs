using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PicoPlaca.Library
{
    public class PicoPlaca
    {
        public static bool IsPlaqueValid(string plaque)
        {
            bool isPlaqueValid = false;
            if (plaque.Length >= 6 || plaque.Length < 8)
            {
                int numbers = Regex.Match(plaque, @"\d+").Value.Length;
                int letters = plaque.Length - numbers;

                if (letters == 3 && (numbers >= 3 || numbers < 5))
                {
                    //First 3 Digits are letters
                    if (Regex.IsMatch(plaque.Substring(0, 2), @"^[a-zA-Z]+$"))
                        isPlaqueValid = true;

                    //Last Digits are letters
                    if (Regex.IsMatch(plaque.Substring(3, numbers), @"\d+"))
                        isPlaqueValid = true;
                }
            }
            return isPlaqueValid;
        }
    }
}
