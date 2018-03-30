using System;
using System.Threading.Tasks;
using UrlopowaTortilla.DataAccess;
using UrlopowaTortilla.Helpers;
using UrlopowaTortilla.Models;

namespace UrlopowaTortilla
{
    class Test
    {
        public static async Task DoTest()
        {
            var daysOffManager = new DaysOffManager();
            var notifier = new Notifier();
            var repository = new HolidayRequestRepository(daysOffManager, notifier);

            var holidayRequest = new HolidayRequest(new TimeSpan(1, 0, 0, 0), notifier, daysOffManager);
            var holidayRequestNumber = holidayRequest.Number;
            repository.Create(holidayRequest);
            holidayRequest.SendToBoss();
            repository.Update(holidayRequest);

            var anotherHolidayRequest = await repository.GetBy(holidayRequestNumber);
            anotherHolidayRequest.Accept();
            repository.Update(anotherHolidayRequest);

            var finalHolidayRequest = await repository.GetBy(holidayRequestNumber);
            finalHolidayRequest.Finish();
            repository.Update(finalHolidayRequest);

            var finalFinalHolidayRequest = await repository.GetBy(holidayRequestNumber);
            Console.WriteLine(finalFinalHolidayRequest.HolidayRequestStatus.GetType().Name);
        }
    }
}