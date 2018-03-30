using System;

namespace UrlopowaTortilla.Helpers
{
    class Notifier : INotifier
    {
        public void NotifyBoss(string message)
        {
            Console.WriteLine($"Noification for boss: {message}");
        }

        public void NotifyEmployee(string message)
        {
            Console.WriteLine($"Noification for employee: {message}");
        }

        public void NotifyTeam(string message)
        {
            Console.WriteLine($"Noification for team: {message}");
        }

        public void NotifyHR(string message)
        {
            Console.WriteLine($"Noification for HR: {message}");
        }
    }
}