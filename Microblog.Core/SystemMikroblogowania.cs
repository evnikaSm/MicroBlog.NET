using System;

namespace Microblog.Core
{
    public class SystemMikroblogowania
    {
        Uzytkownik[] uzytkownicy;
        Tweet[] tweety;
        StatystykiTweetow[] statystyki;
        int liczbaUzytkownikow;
        int liczbaTweetow;

        private int następneIdUżytkownika;
        private int następneIdTweet;

        public Uzytkownik[] Uzytkownicy { get => uzytkownicy; set => uzytkownicy=value; }
        public Tweet[] Tweety { get => tweety; set => tweety=value; }
        public StatystykiTweetow[] Statystyki { get => statystyki; set => statystyki=value; }
        public int LiczbaUzytkownikow { get => liczbaUzytkownikow; set => liczbaUzytkownikow=value; }
        public int LiczbaTweetow { get => liczbaTweetow; set => liczbaTweetow=value; }

        public SystemMikroblogowania(int pojemnosc)
        {
            Uzytkownicy=new Uzytkownik[pojemnosc];
            Tweety = new Tweet[pojemnosc];
            Statystyki = new StatystykiTweetow[pojemnosc];
            LiczbaUzytkownikow = 0;
            LiczbaTweetow = 0;

            następneIdUżytkownika = 1;
            następneIdTweet = 1;
        }
        public Uzytkownik ZarejestrujUzytkownika(string nazwa, string email)
        {
            if (LiczbaUzytkownikow >= Uzytkownicy.Length)
            {
                throw new InvalidOperationException("brak miejsca na nowych uzytkownikow");

            }
            var uzytkownik = new Uzytkownik(następneIdUżytkownika, nazwa, email);
            Uzytkownicy[LiczbaUzytkownikow] = uzytkownik;
            LiczbaUzytkownikow++;
            następneIdUżytkownika++;
            return uzytkownik;
        }
        public Tweet DodajTweet(Uzytkownik autor, string stresc)
        {               
            if (LiczbaTweetow >= Tweety.Length)
                throw new InvalidOperationException("brak miejsca w tablicy");
            var tweet = new Tweet(następneIdTweet,stresc,  autor, DateTime.Now);
            Tweety[LiczbaTweetow] = tweet;
            Statystyki[LiczbaTweetow] = new StatystykiTweetow(0, 0, 0);

            LiczbaTweetow++;
            następneIdTweet++;
            return tweet;
        }
        public void PolubTweet(int tweetId)
        {
            for (int i = 0; i < LiczbaTweetow; i++)
            {
                if (Tweety[i].Id == tweetId)
                {
                    Statystyki[i].LiczbaPolubien++;
                    return;
                }
            }
        }
        public Uzytkownik PobierzNajpopularniejszegoUzytkownika()
        {
            if (LiczbaTweetow == 0)
                return null;

            int maxPolubien = Statystyki[0].LiczbaPolubien;
            Uzytkownik najlepszy = Tweety[0].Autor;

            for (int i = 1; i < LiczbaTweetow; i++)
            {
                if (Statystyki[i].LiczbaPolubien > maxPolubien)
                {
                    maxPolubien = Statystyki[i].LiczbaPolubien;
                    najlepszy = Tweety[i].Autor;
                }
            }

            return najlepszy;
        }
        public void WyswietlWszystkieTweety()
        {
            foreach(Tweet tw in Tweety)
            {
                if (tw != null)
                    Console.WriteLine($"{tw.Id} {tw.Trest} {tw.Autor.NazwaUzytkownika} {tw.DataUtworzenia}");
            }
        }
    }
}
