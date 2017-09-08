using System;

namespace BusinessDayCounting.Holiday
{
    ///- Public holidays which are always on the same day, except when that falls on a weekend. e.g. New Year's Day on January 1st every year, 
    ///unless that is a Saturday or Sunday, in which case the holiday is the next Monday    
    public class ExpWeekendHoliday : IHoliday
    {
        public DateTime Date => GetNextMonday();

        public string Name { get; set; }
        public HolidayType HolidayType { get; set; }

        private bool IsDayOnWeekend()
        {
            var dayOfWeek= (new DateTime(Year,(int)Month,Day)).DayOfWeek;
            return (dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday);
        }

        private DateTime GetNextMonday()
        {
            var dayOfWeek= (new DateTime(Year,(int)Month,Day)).DayOfWeek;
            var date = (new DateTime(this.Year, (int) this.Month, this.Day));

            switch (dayOfWeek)
            {
                case DayOfWeek.Saturday:
                    return date.AddDays(2);
                case DayOfWeek.Sunday:
                    return date.AddDays(1);
                    default:
                        return date;
            }
        }



        public int Day { get; set; }
        public int Year { get; set; }
        public Month Month { get; set; }
    }
}