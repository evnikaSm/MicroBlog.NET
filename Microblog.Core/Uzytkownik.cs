using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Microblog.Core
{
    public class Uzytkownik
    {
        int id;
        string nazwaUzytkownika;
        string email;
        DateTime dataRejestracji;
        int liczbaObserwujacych;

        public int Id { get => id; }
        public string NazwaUzytkownika
        {
            get => nazwaUzytkownika;

            set
            {
                if (value == null || value.Length == 0) nazwaUzytkownika = "uzytkownik domyslny";
                if (value.Length >= 3 && value.Length <= 20)
                    nazwaUzytkownika=value;
                else
                    nazwaUzytkownika =  "uzytkownik domyslny";
            }
        } 
        public string Email 
        { get => email;
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] =='@')
                    {email = value;
                        return;
                    }
                        
                    
                }
                email =  "email@domyslny";
                
            } 
        }
        public DateTime DataRejestracji 
        { 
            get => dataRejestracji;
        }
        public int LiczbaObserwujacych 
        { 
            get => liczbaObserwujacych; 
        }
        public Uzytkownik(int id, string nazwaUzytkownika, string email)
        {
            this.id = id;
            this.NazwaUzytkownika=nazwaUzytkownika;
            this.Email=email;
            this.dataRejestracji = DateTime.Now;
        }
        public Uzytkownik() : this(int.MaxValue, "Uzytkownik1", "emailprzykladowy@gmail.com") { }
        public void Obserwuj(Uzytkownik uzytkownik)
        {
            uzytkownik.liczbaObserwujacych = uzytkownik.liczbaObserwujacych + 1;
        }
        public string PrzedstawSie()
        {
            return $"{this.nazwaUzytkownika} {this.id} {this.Email} {this.dataRejestracji} {this.liczbaObserwujacych}";
        }
    }
}
