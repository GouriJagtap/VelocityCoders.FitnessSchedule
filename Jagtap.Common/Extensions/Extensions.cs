using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jagtap.Common.Extensions
{
    public static class Extensions
    {
        //Attempts to convert string to valid DateTime. If failed returns DateTime.minValue.

        public static DateTime ToDate(this string s)
        {
            DateTime dateTime;
            if (DateTime.TryParse(s, out dateTime))
                return dateTime;
            else
                return DateTime.MinValue;
        }

        //Attempts to Convert string to valid

        public static int ToInt(this string s)
        {
            int intValue = 0 ;
            if (int.TryParse(s, out intValue))
                return intValue;
            else
                return 0;
        }
        //Attempts to convert DateTime into smallDate

        public static string TellTime(this DateTime dt)
        {
            string smallDate;
            smallDate = (dt.ToLongTimeString());
            return smallDate;
        }

        //Attempts to get the first character of a string 

        public static string GetFirstCharacter(this string st)
        {
            string firstChar = st.Substring(0, 1);
            return firstChar;

        }

        //Attempts to convert the int to string 

        public static string ConvertToString (this int x)
        {
            string str = x.ToString();
            return str;
        }


    }
}
