using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi.Classes.Event
{
    public class Event
    {
        private string _title;
        private DateTime _date;
        private int _maxCapacity;

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (value != "")
                    _title = value;
                else
                    throw new Exception("Inserire un Titolo valido");
            }
        }
        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (value > DateTime.Now)
                    _date = value;
                else
                    throw new Exception("Inserire una data valida");
            }
        }
        public int MaxCapacity
        {
            get { return _maxCapacity; }
            private set
            {
                if (value > 0)
                    _maxCapacity = value;
                else
                    throw new Exception("Inserire una capienza maggiore di 0");
            }
        }
        public int ReservedSeats { get; private set; }

        public Event(string title, string date, int maxCapacity)
        {
            Title = title;
            Date = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            MaxCapacity = maxCapacity;
            ReservedSeats = 0;
        }


        //***************************************METHODS

        public void ReservePlace(int seats)
        {
            if (Date < DateTime.Now)
                throw new Exception("Siamo spiacenti l'evento è terminato");

            if (MaxCapacity < ReservedSeats + seats)
                throw new Exception($"Restano {MaxCapacity - ReservedSeats} disponibili");

            ReservedSeats = ReservedSeats + seats;
        }

        public void CancelReservation(int seats)
        {
            if (Date < DateTime.Now)
                throw new Exception("Siamo spiacenti l'evento è terminato");

            if (ReservedSeats < seats)
                throw new Exception($"Non è possibile disdire {seats} {(seats == 1 ? "prenotazione" : "prenotazioni")}");

            ReservedSeats = ReservedSeats - seats;
        }

        public override string ToString()
        {
            return $"\t{this.Date.ToString("dd/MM/yyyy")} - {this.Title}\n";
        }


    }
}
