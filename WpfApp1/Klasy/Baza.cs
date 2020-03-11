using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.Klasy
{
    class Baza
    {
        Baza_Pracownikow pracownicy;
        Baza_Zdarzen zdarzenia;

        Zdarzenie pomocnik_zdarzenie;
        Pracownik pomocnik_pracownik;

        Baza()
        {
            pracownicy = new Baza_Pracownikow();
            zdarzenia = new Baza_Zdarzen();


            pomocnik_zdarzenie = new Zdarzenie(zdarzenia.ilosc_zdarzen);
            pomocnik_pracownik = new Pracownik(pracownicy.ilosc);
        }
    }
}
