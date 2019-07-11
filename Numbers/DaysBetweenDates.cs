using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class DaysBetweenDates
    {
        private int[] monthDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private class Date
        {
            public int year, month, day;
            public Date(int y, int m, int d)
            {
                year = y;
                month = m;
                day = d;
            }
        }

        private bool ValidDate(Date date)
        {
            if (date.month == 2 && date.day == 29) return IsLeapYear(date.year);

            return (date.day > 0 && date.month > 0 && date.year > 0 && date.day <= monthDays[date.month-1]);
        }

        private bool IsLeapYear(int year)
        {
            if (year % 400 == 0) return true;
            if (year % 100 == 0) return false;
            if (year % 4 == 0) return true;
            return false;
        }

        private int LeapDays(Date date)
        {
            int year = date.year;
            if (date.month <= 2) year--;
            return year / 4 + year / 400 - year / 100;
        }

        private Date ConvertToDate(string s)
        {
            string[] date = s.Split('/');
            return new Date(Int32.Parse(date[2]), Int32.Parse(date[0]), Int32.Parse(date[1]));
        }

        private int NumofDays(Date d1)
        {
            int days = d1.year * 365 + LeapDays(d1) + d1.day;
            for (int i = 1; i < d1.month; i++)
                days += monthDays[i-1];
            return days;
        }
        public DaysBetweenDates(string d1, string d2, bool include = true)
        {
            Date date1 = ConvertToDate(d1);
            Date date2 = ConvertToDate(d2);
            if (ValidDate(date1) && ValidDate(date2))
            {
                int days = Math.Abs(NumofDays(date1) - NumofDays(date2));
                if (include) days++;
                Console.WriteLine("No of Days: " + days);
            }
            else
                Console.Write("Invalid Date");



        }

    }
}
