using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

// Used for writing to a file
using System.IO;

// Used to serialize an object to binary format
using System.Runtime.Serialization.Formatters.Binary;

// Used to serialize into XML
using System.Xml.Serialization;


namespace WpfApp1.Klasy
{
    class Baza_Zdarzen
    {
        public string lokalizacja { get; private set; }
        public int ilosc_zdarzen{ get; private set; }
        public List<Zdarzenie> zdarzenia = new List<Zdarzenie>();
        public Baza_Zdarzen()
        {
            lokalizacja = "Zdarzenia";
            ilosc_zdarzen = 0;
        }
        public void dodaj_zdarzenie (Zdarzenie zdarzenie)
        {
            zdarzenia.Add(zdarzenie);
            ilosc_zdarzen++;
        }
        public void edytuj_zdarzenie (int i, Zdarzenie zdarzenie)
        {
            zdarzenia[i] = zdarzenie;
        }
        public void usun_zdarzenie (int i)
        {
            zdarzenia.RemoveAt(i);
        }
        public bool sprawdz_czy_zdarzenie_mozliwe(Zdarzenie zdarzenie)
        {
            bool tmp = true;
            if ((zdarzenia.Exists(x => x.id_zdarzenia == zdarzenie.id_zdarzenia))||(pracownik_ma_czas(zdarzenie))||(stanowisko_wolne(zdarzenie)))
            {
                tmp = false;
            }
            return tmp;
        }

        public bool pracownik_ma_czas (Zdarzenie zdarzenie)
        {
            bool tmp = true;
            for (int i = 0; i < zdarzenia.Count; i++)
            {
                if (zdarzenia[i].id_pracownika == zdarzenie.id_pracownika && 
                    ((zdarzenia[i].zdarzenie_w_trakcie(zdarzenie.data_rozpoczęcia)|| zdarzenia[i].zdarzenie_w_trakcie(zdarzenie.data_zakonczenia)) ||
                    (zdarzenie.zdarzenie_w_trakcie(zdarzenia[i].data_rozpoczęcia) || zdarzenie.zdarzenie_w_trakcie(zdarzenia[i].data_zakonczenia))))
                {
                    tmp = false;
                    break;
                }
            }
            return tmp;
        }

        public bool stanowisko_wolne(Zdarzenie zdarzenie)
        {
            bool tmp = true;
            for (int i = 0; i < zdarzenia.Count; i++)
            {
                if (zdarzenia[i].id_stanowiska == zdarzenie.id_stanowiska &&
                    ((zdarzenia[i].zdarzenie_w_trakcie(zdarzenie.data_rozpoczęcia) || zdarzenia[i].zdarzenie_w_trakcie(zdarzenie.data_zakonczenia)) ||
                    (zdarzenie.zdarzenie_w_trakcie(zdarzenia[i].data_rozpoczęcia) || zdarzenie.zdarzenie_w_trakcie(zdarzenia[i].data_zakonczenia))))
                {
                    tmp = false;
                    break;
                }
            }
            return tmp;
        }

        public void zapis ()
        {
            using (Stream fs = new FileStream(plik(),
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Zdarzenie>));
                serializer.Serialize(fs, zdarzenia);
            }
        }

        public void odczyt()
        {
            zdarzenia = null;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Zdarzenie>));

            using (FileStream fs = File.OpenRead(plik()))
            {
                zdarzenia = (List<Zdarzenie>)serializer.Deserialize(fs);
            }
            ilosc_zdarzen = zdarzenia.Count;
        }
        private string plik()
        {
            return "@"+lokalizacja;
        }

        public void plik (string a)
        {
            lokalizacja = a;
        }
    }
}
