using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microblog.Core
{
    public struct StatystykiTweetow
    {
        public int LiczbaPolubien;
        public int LiczbaRetweetow;
        public int LiczbaKomentarzy;

        public StatystykiTweetow(int liczbaPolubien, int liczbaRetweetow, int liczbaKomentarzy)
        {
            LiczbaPolubien=liczbaPolubien;
            LiczbaRetweetow=liczbaRetweetow;
            LiczbaKomentarzy=liczbaKomentarzy;
        }

        public void WyswietlStatystyki()
        {
            Console.WriteLine($"{this.LiczbaPolubien} {this.LiczbaRetweetow} {this.LiczbaKomentarzy}");
        }
    }
}
