using System;

namespace UrlopowaTortilla.Helpers
{
    public interface IDaysOffManager
    {
        void IncreaseDaysOff(int daysAmount);
        void DecreaseDaysOff(int daysAmount);
    }

    class DaysOffManager : IDaysOffManager
    {
        public void IncreaseDaysOff(int daysAmount)
        {
            Console.WriteLine("Days off amount has been increased!");
        }

        public void DecreaseDaysOff(int daysAmount)
        {
            Console.WriteLine("Days off amount has been decreased!");
        }
    }
}