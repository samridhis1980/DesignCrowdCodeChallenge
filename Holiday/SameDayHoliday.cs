using System;

namespace BusinessDayCounting.Holiday
{
    //- Public holidays which are always on the same day, e.g. Anzac Day on April 25th every year.
    public class SameDayHoliday : IHoliday
    {
        public int Day { get; set; }
        public DateTime Date => new DateTime( this.Year,(int)this.Month,this.Day);
        public string Name { get; set; }
        public HolidayType HolidayType { get; set; }
        public int Year { get; set; }
        public Month Month { get; set; }
    }
}