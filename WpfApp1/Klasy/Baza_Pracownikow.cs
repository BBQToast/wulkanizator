﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
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
    class Baza_Pracownikow
    {
        public int ilosc { get; private set; }
        public string lokalizacja { get; private set; }

        public List<Pracownik> pracownicy = new List<Pracownik>();

        public Baza_Pracownikow()
        {
            lokalizacja = "Pracownicy";
            ilosc = 0;
        }
        private static string polącz_z_baza (string id = "Baza")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        public bool zapisz_pracownika (Pracownik pracownik)
        {
            bool tmp = false;
            if (sprawdzenie_pracownika(pracownik))
            {
                pracownicy.Add(pracownik);
                ilosc++;
                tmp = true;
            }
            return tmp;
        }

        public bool edytuj_pracownika(int i, Pracownik pracownik)
        {
            bool tmp = false;
            if (pracownicy.Count >= i)
            {
                pracownicy[i] = pracownik;
                tmp = true;
            }
            return tmp;
        }

        public bool usun_pracownika (int i)
        {
            bool tmp = false;
            if (pracownicy.Count >= i)
            {
                pracownicy.RemoveAt(i);
                tmp = true;
            }
            return tmp;
        }
         private bool sprawdzenie_pracownika (Pracownik pracownik)
        {
            bool tmp = true;

            if (pracownicy.Exists(x => x.ID == pracownik.ID) || 
                pracownicy.Exists(x => x.telefon == pracownik.telefon) || 
                pracownicy.Exists(x => x.pesel == pracownik.pesel) ||
                pracownicy.Exists(x => x.Mail == pracownik.Mail))
            {
                tmp = false;
            }

            return tmp;
        }

        public void zapis()
        {
            using (Stream fs = new FileStream(plik(),
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Pracownik>));
                serializer.Serialize(fs, pracownicy);
            }
        }

        public void odczyt()
        {
            pracownicy = null;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Pracownik>));

            using (FileStream fs = File.OpenRead(plik()))
            {
                pracownicy = (List<Pracownik>)serializer.Deserialize(fs);
            }
            ilosc = pracownicy.Count;
        }
        private string plik()
        {
            return "@" + lokalizacja;
        }

        public void plik(string a)
        {
            lokalizacja = a;
        }
    }
}
