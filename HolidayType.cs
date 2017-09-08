namespace BusinessDayCounting
{
    public enum HolidayType
    {
        //doesn't get extra holiday if on weekend
        SameDay =0,
        //Occur on next monday(holiday) if falls on weekend
        ExpWeekend=1,
        //e.g. 2nd Monday in June every year.
        DayOfWeek=2
    }
}