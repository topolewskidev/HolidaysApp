using System;

namespace UrlopowaTortilla.States
{
    class New : IHolidayRequestState
    {
        public IHolidayRequestState SendToBoss(Action callback)
        {
            callback();
            return new PendingForBossAcceptation();
        }

        public IHolidayRequestState Accept(Action callback) => this;
        public IHolidayRequestState Finish(Action callback) => this;
    }
}