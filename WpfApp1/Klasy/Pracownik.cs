using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace WpfApp1.Klasy
{
    [Serializable()]
    public class Pracownik : ISerializable
    {
        public int ID { get; set; }
        public string Imie { get ; set; }
        public string Nazwisko { get ; set; }
        public string Mail { get; set; }
        public string telefon { get; set; }
        public int pesel { get; set; }
        public DateTime Data_zatrudnienia { get ; set ; }
        public DateTime Data_zakonczenia_pracy { get ; set; }

        public Pracownik(int liczba)
        {
            ID = liczba;
            Data_zatrudnienia = DateTime.Now;
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
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id_pracownika", ID);
            info.AddValue("Imie", Imie);
            info.AddValue("Nazwisko", Nazwisko);
            info.AddValue("Mail", Mail);
            info.AddValue("telefon", telefon);
            info.AddValue("pesel", pesel);
            info.AddValue("data_rozpoczecia", Data_zatrudnienia);
            info.AddValue("data_zakonczenia", Data_zakonczenia_pracy);
        }

        public Pracownik(SerializationInfo info, StreamingContext ctxt)
        {
            ID = (int)info.GetValue("id_pracownika", typeof(int));
            Imie = (string)info.GetValue("Imie", typeof(string));
            Nazwisko = (string)info.GetValue("Nazwisko", typeof(string));
            Mail = (string)info.GetValue("Mail", typeof(string));
            telefon = (string)info.GetValue("telefon", typeof(string));
            pesel = (int)info.GetValue("pesel", typeof(int));
            Data_zatrudnienia = (DateTime)info.GetValue("data_zakonczenia", typeof(DateTime));
            Data_zakonczenia_pracy = (DateTime)info.GetValue("data_zakonczenia", typeof(DateTime));
        }
    }

}
