using System;

namespace BusinessDayCounting.Holiday
{
    public interface IHoliday
    {
        DateTime Date { get; }
        string Name { get; set; }
        HolidayType HolidayType { get; set; }
        
        int Year { get; set; }
        Month Month { get; set; }

    }
}