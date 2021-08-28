using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace NflStats.Loader.Helpers
{
    public static class DataHelper
    {
        
        public static int ParseInt(string value)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            return 0;
        }

        public static long ParseLong(string value)
        {
            if (long.TryParse(value, out long result))
            {
                return result;
            }
            return 0;
        }

        public static double ParseDouble(string value)
        {
            if (double.TryParse(value, out double result))
            {
                return result;
            }
            return 0;
        }

        public static DateTime? ParseDateTime(string value, string format)
        {
            

            if (!string.IsNullOrEmpty(format) && DateTime.TryParseExact(value, format, new CultureInfo("en-US"), DateTimeStyles.None, out DateTime result))
            {
                return result;
            }
            else
            {
                if (DateTime.TryParse(value, out DateTime result2))
                {
                    return result2;
                }
            }
            return null;
        }

        public static int SplitInteger(string value, string character, int index)
        {
            string[] parts = value.Split(character);
            if (parts.Length - 1 >= index)
            {
                return ParseInt(parts[index]);
            }
            return 0;

        }

        public static long SplitLong(string value, string character, int index)
        {
            string[] parts = value.Split(character);
            if (parts.Length - 1 >= index)
            {
                return ParseLong(parts[index]);
            }
            return 0;
        }

        public static double SplitDouble(string value, string character, int index)
        {
            string[] parts = value.Split(character);
            if (parts.Length - 1 >= index)
            {
                return ParseDouble(parts[index]);
            }
            return 0;
        }

    }
}
