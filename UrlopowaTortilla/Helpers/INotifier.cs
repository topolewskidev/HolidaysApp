namespace UrlopowaTortilla.Helpers
{
    public interface INotifier
    {
        void NotifyBoss(string message);
        void NotifyEmployee(string message);
        void NotifyTeam(string message);
        void NotifyHR(string message);
    }
}