using System;

namespace WindowsFormsApp4
{
    static class DateTimeIso
    {
        // This class return current date and time in specific format (ISO 8601)
        // https://ru.wikipedia.org/wiki/ISO_8601
        // http://www.csharp-examples.net/string-format-datetime/
        // Autor: Pavlo Rusnak
        public static string GetYearNow()
        {
            return String.Format("{0:yyyy}", DateTime.Now);
        }

        public static string GetTimeNow()
        {
           return GetTimeNow(false);
        }

        public static string GetTimeNow(bool standartFormat)
        {
            if (standartFormat == true)
            {
                return String.Format("{0:HH:mm:ss}", DateTime.Now);
            }
            else
            {
                return String.Format("{0:THH-mm-ss}", DateTime.Now);
            }
        }

        public static string GetDateNow()
        {
           return GetDateNow(false);
        }

        public static string GetDateNow(bool standartFormat)
        {
            if (standartFormat == true)
            {
                return String.Format("{0:yyyy-MM-dd}", DateTime.Now);
            }
            else
            {
                return String.Format("{0:yyyyMMdd}", DateTime.Now);
            }
        }

        public static string GetDateAndTimeNow()
        {
            return GetDateAndTimeNow(false);
        }

        public static string GetDateAndTimeNow(bool standartFormat)
        {
            if (standartFormat == true)
            {
                return String.Format("{0:yyyy-MM-ddTHH-mm-ss}", DateTime.Now);
            }
            else
            {
                return String.Format("{0:yyyyMMddTHHmmss}", DateTime.Now);
            }

        }
    }




}
