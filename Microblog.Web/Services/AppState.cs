using Microblog.Core;

namespace Microblog.Web.Services
{
    public static class AppState
    {
        public static SystemMikroblogowania System { get; } = CreateSystem();

        private static SystemMikroblogowania CreateSystem()
        {
            var system = new SystemMikroblogowania(50);

            var u1 = system.ZarejestrujUzytkownika("dev_girl", "dev@example.com");
            var u2 = system.ZarejestrujUzytkownika("code_master", "code@example.com");

            system.DodajTweet(u1, "My first tweet in ASP.NET Core MVC");
            system.DodajTweet(u2, "Building a small web app from an OOP assignment");
            system.DodajTweet(u1, "Now it looks like a real project");

            return system;
        }
    }
}