using System;

namespace BusinessDayCounting.Holiday
{
    //e.g. comes 2nd Monday of Feb Every year
    //    - Public holidays on a certain occurrence of a certain day in a month. e.g. Queen's Birthday on the second Monday in June every year.
    public class DayOfWeekHoliday : IHoliday
    {
        public DateTime Date => (new DateTime(Year, (int)Month, 01))
            .NthWeekDayOfMonth(DayOfWeek,NthNumber);

        public string Name { get; set; }
        public HolidayType HolidayType { get; set; }
        public int Year { get; set; }
        public Month Month { get; set; }
        public int NthNumber { get; set; }//e.g 2nd or 3rd week
        public DayOfWeek DayOfWeek { get; set; }
    }
}