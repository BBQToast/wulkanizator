using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace WpfApp1.Klasy
{
    public class Pracownik
    {
        public int ID { get; set; }
        public string Imie { get ; set; }
        public string Nazwisko { get ; set; }
        public string Mail { get; set; }
        public string telefon { get; set; }
        public int pesel { get; set; }
        public DateTime Data_zatrudnienia { get ; set ; }
        public DateTime Data_zakonczenia_pracy { get ; set; }

        public Pracownik()
        {
            
        }

        public bool Czy_aktywny ()
        {
            bool tmp = true;

            if (Data_zakonczenia_pracy > Data_zatrudnienia)
            {
                tmp = false;
            }

            return tmp;
        }

    }

}
