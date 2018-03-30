using System;

namespace UrlopowaTortilla.States
{
    public interface IHolidayRequestState
    {
        IHolidayRequestState SendToBoss(Action callback);
        IHolidayRequestState Accept(Action callback);
        IHolidayRequestState Finish(Action callback);
    }
}