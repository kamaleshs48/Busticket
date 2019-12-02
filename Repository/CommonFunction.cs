using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace KanakHolidays.Repository
{
    public sealed class CommonFunction
    {
        public static DateTime ConvertToDateTime(string _Date, string Format)
        {
            DateTime dt;
            DateTime.TryParseExact(_Date,
                                   Format,
                                   CultureInfo.InvariantCulture,
                                   DateTimeStyles.None,
                                   out dt);
            return dt;
        }

        public static string GetTicketNo()
        {
            Random _rdm = new Random();
            return "KAN-" + DateTime.Now.ToString("ddMMyy") + _rdm.Next(1000, 9999).ToString();
        }

    }
}