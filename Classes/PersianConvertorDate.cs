using System;
using System.Collections.Generic;
using System.Globalization;

namespace ACMS
{
    static public class PersianConvertorDate
    {
        public static string ToShamsi(this DateTime value)
        {
            var values = value;

            string DayName = "";
            switch (values.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    DayName = " شنبه ";
                    break;
                case DayOfWeek.Sunday:
                    DayName = " یکشنبه ";
                    break;
                case DayOfWeek.Monday:
                    DayName = " دوشنبه ";
                    break;
                case DayOfWeek.Tuesday:
                    DayName = " سه شنبه ";
                    break;
                case DayOfWeek.Wednesday:
                    DayName = " چهارشنبه ";
                    break;
                case DayOfWeek.Thursday:
                    DayName = " پنج شنبه ";
                    break;
                case DayOfWeek.Friday:
                    DayName = " جمـــعه ";
                    break;
            }

            PersianCalendar pc = new PersianCalendar();
           



            return
                DayName + " ، " + pc.GetHour(value).ToString("00") + ":" + pc.GetMinute(value).ToString("00") + " ، " + pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
             pc.GetDayOfMonth(value).ToString("00");
        }

    }
}