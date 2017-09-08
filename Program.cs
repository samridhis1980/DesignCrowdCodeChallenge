using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessDayCounting.Holiday;

namespace BusinessDayCounting
{
    class Program
    {
        static void Main(string[] args)
        {
            /// TASK 1: Weekday counting

            // Monday 07-Oct-2013 and Wednesday 09-Oct-2013 : should return 1
            int value1 = BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 10, 9));

            // Saturday 05-Oct-2013 and Monday 14-Oct-2013 : should return 5
            int value2 = BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 5), new DateTime(2013, 10, 14));

            // Monday 07-Oct-2013 and Wednesday 01-Jan-2014 : should return 61
            int value3 = BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2014, 1, 1));

            // Monday 07-Oct-2013 and Saturday 05-Oct-2013 : should return 0 (second date earlier than first date)
            int value4 = BusinessDayCounter.WeekdaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 10, 5));

            
            /// TASK 2: Business day counting

            // Public holiday list containing Christmas Day, Boxing Day and New Year's Day
            List<DateTime> publicHolidays = new List<DateTime> 
            {
                new DateTime(2013, 12, 25),
                new DateTime(2013, 12, 26), 
                new DateTime(2014, 1, 1) 
            };

            // Monday 07-Oct-2013 and Wednesday 09-Oct-2013 : should still return 1
            int value5 = BusinessDayCounter.BusinessDaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2013, 10, 9), publicHolidays);

            // Tuesday 24-Dec-2013 and Friday 27-Dec-2013 : should return 0, both days are public holidays
            int value6 = BusinessDayCounter.BusinessDaysBetweenTwoDates(new DateTime(2013, 12, 24), new DateTime(2013, 12, 27), publicHolidays);

            // Monday 07-Oct-2013 and Wednesday 01-Jan-2014 : should return 59
            int value7 = BusinessDayCounter.BusinessDaysBetweenTwoDates(new DateTime(2013, 10, 7), new DateTime(2014, 1, 1), publicHolidays);
         
            
            /// TASK 3: Business day counting using complex rules
            // Public holiday list containing Christmas Day, Boxing Day and New Year's Day
            List<IHoliday> publicExtHolidays = new List<IHoliday>();
            //- Public holidays which are always on the same day, e.g. Anzac Day on April 25th every year.
            publicExtHolidays.Add(new SameDayHoliday{  Year = 2017, Month = Month.April, Day = 25, Name = "Anzac Day"});
            
            //- Public holidays which are always on the same day, except when that falls on a weekend. e.g. New Year's Day on January 1st every year, 
            //    unless that is a Saturday or Sunday, in which case the holiday is the next Monday.
            publicExtHolidays.Add(new ExpWeekendHoliday{  Year = 2017, Month = Month.January, Day = 1, Name = "New Year"});

            //- Public holidays on a certain occurrence of a certain day in a month. e.g. Queen's Birthday on the second Monday in June every year.
            publicExtHolidays.Add(new DayOfWeekHoliday{  Year = 2017, Month = Month.June, NthNumber = 2, DayOfWeek  = DayOfWeek.Monday, Name = "Queen's Birthday "});           
            
            //- Public holidays which are always on the same day, e.g. Anzac Day on April 25th every year. 
            //: should return 2
            int value15 = BusinessDayCounter.BusinessDaysBetweenTwoDates(new DateTime(2017, 4, 21), new DateTime(2017, 4, 27), publicExtHolidays);

            //- Public holidays which are always on the same day, except when that falls on a weekend. e.g. New Year's Day on January 1st every year, 
            //    unless that is a Saturday or Sunday, in which case the holiday is the next Monday.
            //Should return 2
            int value16 = BusinessDayCounter.BusinessDaysBetweenTwoDates(new DateTime(2017, 1, 1), new DateTime(2017, 1, 5), publicExtHolidays);

            //- Public holidays on a certain occurrence of a certain day in a month. e.g. Queen's Birthday on the second Monday in June every year.
            //Should return 3
            int value17 = BusinessDayCounter.BusinessDaysBetweenTwoDates(new DateTime(2017, 6, 11), new DateTime(2017, 6, 16), publicExtHolidays);

        }
    }
}
