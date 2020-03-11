using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WpfApp1.Klasy
{
    class Baza
    {
        Baza_Pracownikow pracownicy;
        Baza_Zdarzen zdarzenia;

        Zdarzenie pomocnik_zdarzenie;
        Pracownik pomocnik_pracownik;

        string lok_zdarzenia;
        string lok_pracownicy;

        Baza()
        {
            pracownicy = new Baza_Pracownikow();
            zdarzenia = new Baza_Zdarzen();

            try 
            {
                var path = @"data.txt";
                string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            }
            catch(Exception e)
            {

            }

            pomocnik_zdarzenie = new Zdarzenie(zdarzenia.ilosc_zdarzen);
            pomocnik_pracownik = new Pracownik(pracownicy.ilosc);
        }
    }
}
