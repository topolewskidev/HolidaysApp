using System;

namespace UrlopowaTortilla.DataAccess
{
    public class HolidayRequestEntity
    {
        public string Number { get; set; }
        public string Status { get; set; }
        public TimeSpan HolidayPeriod { get; set; }
    }
}