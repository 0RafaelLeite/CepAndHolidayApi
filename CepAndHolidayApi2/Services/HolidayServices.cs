using System.Collections.Generic;
using System.Net;
using CepAndHoliday.Models;

namespace CepAndHoliday.Services
{
    public interface IHolidayServices
    {

        public static DateTime GetEasterDate(int year)
        {
            int day;
            int month;

            int lunarCyclePosition = year % 19;
            int century = year / 100;
            int daysFromEquinoxToNextFullMoon = (century - (int)(century / 4) - (int)((8 * century + 13) / 25) + 19 * lunarCyclePosition + 15) % 30;
            int daysFromFullMoonToFirstSunday = daysFromEquinoxToNextFullMoon - (int)(daysFromEquinoxToNextFullMoon / 28) * (1 - (int)(daysFromEquinoxToNextFullMoon / 28) * (int)(29 / (daysFromEquinoxToNextFullMoon + 1)) * (int)((21 - lunarCyclePosition) / 11));

            day = daysFromFullMoonToFirstSunday - ((year + (int)(year / 4) + daysFromFullMoonToFirstSunday + 2 - century + (int)(century / 4)) % 7) + 28;
            month = 3;

            if (day > 31)
            {
                month++;
                day -= 31;
            }

            //where did all of this math come from https://stackoverflow.com/questions/2510383/how-can-i-calculate-what-date-good-friday-falls-on-given-a-year

            return new DateTime(year, month, day);
        }

        public static List<DateTime> SetHolidayDates(DateTime date)
        {

            var HolidayDates = new List<DateTime>();

            var easter = GetEasterDate(date.Year);

            HolidayDates.Add(easter);
            HolidayDates.Add(easter.AddDays(60));
            HolidayDates.Add(easter.AddDays(-47));
            HolidayDates.Add(easter.AddDays(-46));
            HolidayDates.Add(easter.AddDays(-2));
            HolidayDates.Add(new DateTime(date.Year, 1, 1));
            HolidayDates.Add(new DateTime(date.Year, 12, 25));
            HolidayDates.Add(new DateTime(date.Year, 4, 21));
            HolidayDates.Add(new DateTime(date.Year, 11, 15));
            HolidayDates.Add(new DateTime(date.Year, 11, 2));
            HolidayDates.Add(new DateTime(date.Year, 10, 12));
            HolidayDates.Add(new DateTime(date.Year, 9, 7));
            HolidayDates.Add(new DateTime(date.Year, 5, 1));

            return HolidayDates;
        }

        public static Holiday IsHoliday(DateTime date, Holiday holiday)
        {
            var Holidays = SetHolidayDates(date);
            if (Holidays.Contains(date))
            {
                holiday.IsHoliday = true;
            }

            return holiday;
        }
    }
}
