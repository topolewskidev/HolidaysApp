using System;

namespace UrlopowaTortilla.States
{
    class Accepted : IHolidayRequestState
    {
        public IHolidayRequestState SendToBoss(Action callback) => this;
        public IHolidayRequestState Accept(Action callback) => this;
        public IHolidayRequestState Finish(Action callback)
        {
            callback();
            return new Finished();
        }
    }
}