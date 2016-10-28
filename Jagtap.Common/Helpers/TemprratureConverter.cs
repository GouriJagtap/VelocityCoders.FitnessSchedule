using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jagtap.Common.Helpers
{
    public static class TemprratureConverter
    {
        public static double CelsiusToFahrenheit(string temeparuteCelsius)
        {
            //Convert argument to double for calculator
            double celsius = Double.Parse(temeparuteCelsius);

            //Convert  Celsius to Fahrenheit

            double fahrenheit = (celsius * 9 / 5) + 32;

            return fahrenheit; 
        }

        public static double FahrenheitToCelsius(string tempratureFahrenheit)
        {
            double fahrenheit = Double.Parse(tempratureFahrenheit);
            double celsius = (fahrenheit - 32) * 5 / 9;
            return celsius;

        }

    }
}
