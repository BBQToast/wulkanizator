using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WpfApp1.Klasy
{
    [Serializable()]
    class Zdarzenie : ISerializable
    {
        public int id_zdarzenia { get; set; }
        public int typ_zdarzenia { get; set; }
        public int id_pracownika { get; set; }
        public int id_stanowiska { get; set; }
        public string komentarz { get; set; }
        public DateTime data_rozpoczęcia { get; set; }
        public DateTime data_zakonczenia { get; set; }

        public Zdarzenie(int id = -1, int typ = -1, int prac = -1, int stanowisko = -1, string kom = "")
        {
            id_zdarzenia = id;
            typ_zdarzenia = typ;
            id_pracownika = prac;
            id_stanowiska = stanowisko;
            komentarz = kom;
            data_rozpoczęcia = DateTime.Now;
            data_zakonczenia = DateTime.Now;
        }
        public TimeSpan długość_zdarzenia()
        {
            return data_zakonczenia - data_rozpoczęcia;
        }
        public bool zdarzenie_w_trakcie()
        {
            bool tmp = false;
            if(data_zakonczenia >= DateTime.Now && data_rozpoczęcia <= DateTime.Now)
            {
                tmp = true;
            }
            return tmp;
        }
        public bool zdarzenie_w_trakcie(DateTime termin)
        {
            bool tmp = false;
            if (data_zakonczenia >= termin && data_rozpoczęcia <= termin)
            {
                tmp = true;
            }
            return tmp;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id_zdarzenia", id_zdarzenia);
            info.AddValue("typ_zdarzenia", typ_zdarzenia);
            info.AddValue("id_pracownika", id_pracownika);
            info.AddValue("id_stanowiska", id_stanowiska);
            info.AddValue("komentarz", komentarz);
            info.AddValue("data_rozpoczecia", data_rozpoczęcia);
            info.AddValue("data_zakonczenia", data_zakonczenia);
        }

        public Zdarzenie(SerializationInfo info, StreamingContext ctxt)
        {
            id_zdarzenia = (int)info.GetValue("id_zdarzenia", typeof(int));
            typ_zdarzenia = (int)info.GetValue("typ_zdarzenia", typeof(int));
            id_pracownika = (int)info.GetValue("id_pracownika", typeof(int));
            id_stanowiska = (int)info.GetValue("id_stanowiska", typeof(int));
            komentarz = (string)info.GetValue("komentarz", typeof(string));
            data_rozpoczęcia = (DateTime)info.GetValue("data_rozpoczecia", typeof(DateTime));
            data_zakonczenia = (DateTime)info.GetValue("data_zakonczenia", typeof(DateTime));
        }
    }
}
