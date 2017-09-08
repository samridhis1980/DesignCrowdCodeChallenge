using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using BusinessDayCounting.Holiday;

namespace BusinessDayCounting
{
    public static class ExtensionHelper
    {
        public static bool IsWeekDay(this DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Monday || date.DayOfWeek == DayOfWeek.Tuesday || date.DayOfWeek == DayOfWeek.Wednesday || 
                date.DayOfWeek == DayOfWeek.Thursday ||
                date.DayOfWeek == DayOfWeek.Friday)
            {
                return true;
            }
            return false;            
        }
        
        public static DateTime NthWeekDayOfMonth(this DateTime date, DayOfWeek dayOfWeek,int nth) { 
            return (date.AddDays((dayOfWeek < date.DayOfWeek ? 7 : 0) + dayOfWeek - date.DayOfWeek)).AddDays((nth - 1) * 7); 
        }

    }

/*    public class Holiday
    {
        public HolidayType HolidayType { get; set; }
        public DateTime HolidayDate { get; set; }
        public Month? Month { get; set; }
        public int WeekNumber { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
    }*/

    public class BusinessDayCounter
    {
        /// <summary>
        /// TASK ONE:
        /// Calculates the number of weekdays in between two dates.
        /// </summary>
        /// <remarks>
        /// Weekdays are Monday, Tuesday, Wednesday, Thursday, Friday.
        /// The returned count should not include either firstDate or secondDate - e.g. between Monday 07-Oct-2013 and Wednesday 09-Oct-2013 is one weekday.
        /// If secondDate is equal to or before firstDate, return 0.
        /// </remarks>
        /// <param name="firstDate">The first date.</param>
        /// <param name="secondDate">The second date.</param>
        /// <returns>Number of weekdays</returns>
        public static int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {        
            return GetDaysBetweenDates(firstDate, secondDate,new List<DateTime>());
        }


        private static int GetDaysBetweenDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)
        {
            //List<DateTime> Weekdays=new List<DateTime>();
            /// If secondDate is equal to or before firstDate, return 0.
            if (DateTime.Compare(firstDate, secondDate) >= 0)
            {
                return 0;
            }
            
            else
            {
                int TotalWeekDays=0;
                for (var date = firstDate.AddDays(1);date<secondDate;date=date.AddDays(1))
                {
                    if ((publicHolidays != null && publicHolidays.All(x => x.Date != date)) || publicHolidays == null)
                    {                    
                        if (date.IsWeekDay())
                        {
                            TotalWeekDays++;
                        }
                    }
                }
                return TotalWeekDays;
            }
        }
        
        private static int GetDaysBetweenDates(DateTime firstDate, DateTime secondDate, IList<IHoliday> publicHolidays)
        {
            //List<DateTime> Weekdays=new List<DateTime>();
            /// If secondDate is equal to or before firstDate, return 0.
            if (DateTime.Compare(firstDate, secondDate) >= 0)
            {
                return 0;
            }
            
            else
            {
                int TotalWeekDays=0;
                for (var date = firstDate.AddDays(1);date<secondDate;date=date.AddDays(1))
                {
                    if ((publicHolidays != null && publicHolidays.All(x => x.Date != date)) || publicHolidays == null)
                    {                    
                        if (date.IsWeekDay())
                        {
                            TotalWeekDays++;
                        }
                    }
                }
                return TotalWeekDays;                
            }
        }


        /// <summary>
        /// TASK TWO:
        /// Calculates the number of business days in between two dates.
        /// </summary>
        /// <remarks>
        /// Business days are Monday, Tuesday, Wednesday, Thursday, Friday, but excluding any dates which appear in the supplied list of public holidays.
        /// The returned count should not include either firstDate or secondDate - e.g. between Monday 07-Oct-2013 and Wednesday 09-Oct-2013 is one weekday.
        /// If secondDate is equal to or before firstDate, return 0.
        /// </remarks>
        /// <param name="firstDate">The first date.</param>
        /// <param name="secondDate">The second date.</param>
        /// <param name="publicHolidays">List of public holidays.</param>
        /// <returns>Number of business days</returns>
        public static int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)
        {
            return GetDaysBetweenDates(firstDate, secondDate, publicHolidays);
        }

        /// <summary>
        /// TASK TWO:
        /// Calculates the number of business days in between two dates.
        /// </summary>
        /// <remarks>
        /// Business days are Monday, Tuesday, Wednesday, Thursday, Friday, but excluding any dates which appear in the supplied list of public holidays.
        /// The returned count should not include either firstDate or secondDate - e.g. between Monday 07-Oct-2013 and Wednesday 09-Oct-2013 is one weekday.
        /// If secondDate is equal to or before firstDate, return 0.
        /// </remarks>
        /// <param name="firstDate">The first date.</param>
        /// <param name="secondDate">The second date.</param>
        /// <param name="publicHolidays">List of public holidays.</param>
        /// <returns>Number of business days</returns>
        public static int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<IHoliday> publicHolidays)
        {
            return GetDaysBetweenDates(firstDate, secondDate, publicHolidays);
        }
    }
}
