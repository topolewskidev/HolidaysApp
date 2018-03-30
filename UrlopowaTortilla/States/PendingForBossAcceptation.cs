using System;

namespace UrlopowaTortilla.States
{
    class PendingForBossAcceptation : IHolidayRequestState
    {
        public IHolidayRequestState SendToBoss(Action callback) => this;
        public IHolidayRequestState Accept(Action callback)
        {
            callback();
            return new Accepted();
        }

        public IHolidayRequestState Finish(Action callback) => this;
    }
}