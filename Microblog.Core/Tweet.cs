using System;
using System.Collections.Generic;
using System.Text;

namespace Microblog.Core
{
    public record Tweet(int Id, string Trest, Uzytkownik Autor, DateTime DataUtworzenia)
    {
        public string SkroconaTresc
        {
            get
            {
                string res = "";
                for (int i = 0; i < Trest.Length && i < 50; i++)
                {
                    res += Trest[i];
                }
                return res;
            }
        }
        public void Wyswietl()
        {
            Console.WriteLine($"{this.Id} {this.Trest} {this.Autor} {this.DataUtworzenia}");
        }
    }
}
