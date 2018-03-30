using System;

namespace UrlopowaTortilla.States
{
    class Finished : IHolidayRequestState
    {
        public IHolidayRequestState SendToBoss(Action callback) => this;
        public IHolidayRequestState Accept(Action callback) => this;
        public IHolidayRequestState Finish(Action callback) => this;
    }
}