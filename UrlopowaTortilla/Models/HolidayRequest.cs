using System;
using UrlopowaTortilla.Helpers;
using UrlopowaTortilla.States;

namespace UrlopowaTortilla.Models
{
    public class HolidayRequest
    {
        private readonly INotifier _notifier;
        private readonly IDaysOffManager _daysOffManager;

        public HolidayRequest(TimeSpan holidayPeriod, INotifier notifier, IDaysOffManager daysOffManager)
        {
            _notifier = notifier;
            _daysOffManager = daysOffManager;
            HolidayPeriod = holidayPeriod;
            HolidayRequestStatus = new New();
            Number = Guid.NewGuid().ToString();
        }

        public IHolidayRequestState HolidayRequestStatus { get; set; }
        public TimeSpan HolidayPeriod { get; }
        public string Number { get; private set; }

        public void SendToBoss()
        {
            HolidayRequestStatus = HolidayRequestStatus.SendToBoss(() =>
            {
                _daysOffManager.DecreaseDaysOff(HolidayPeriod.Days);
                _notifier.NotifyBoss("New holiday request");
            });
        }

        public void Accept()
        {
            HolidayRequestStatus = HolidayRequestStatus.Accept(() =>
            {
                _notifier.NotifyEmployee("You got replaced, jsut kidding have a great time!");
                _notifier.NotifyTeam("You miss me?");
            });
        }

        public void Finish()
        {
            HolidayRequestStatus = HolidayRequestStatus.Finish(() => _notifier.NotifyHR("I'm back, bitches"));
        }
    }
}