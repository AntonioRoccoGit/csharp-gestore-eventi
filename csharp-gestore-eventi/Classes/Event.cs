using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi.Classes
{
    public class Event
    {
        private string _title; 
        private DateTime _data;
        private int _maxCapacity;

        public string Title {
            get 
            {
                return _title;
                }
            set 
            {
                if (value != "")
                    this._title = value;
                else
                    throw new Exception("Inserire un Titolo valido");
            } 
        }
        public DateTime Data { 
            get { return _data; }
            set { 
                if( value > DateTime.Now)
                    this._data = value;
                else
                    throw new Exception("Inserire una data valida");
            }
        }
        public int MaxCapacity { 
            get { return _maxCapacity; }
            private set 
            {
                if (value > 0)
                    this._maxCapacity = value;
                else
                    throw new Exception("Inserire una capienza maggiore di 0");
            } 
        }
        public int ReservedSeats { get; private set; }

        public Event(string title, string data, int maxCapacity)
        {
            this.Title = title;
            this.Data = DateTime.ParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            this.MaxCapacity = maxCapacity;
            this.ReservedSeats = 0;
        }


        //***************************************METHODS

        public void ReservePlace(int seats)
        {
            if (this.Data < DateTime.Now)
                throw new Exception("Siamo spiacenti l'evento è terminato");

            if (this.MaxCapacity < this.ReservedSeats + seats)
                throw new Exception($"Restano {this.MaxCapacity - this.ReservedSeats} disponibili");

            this.ReservedSeats = this.ReservedSeats + seats;
        }

        public void CancelReservation(int seats)
        {
            if (this.Data < DateTime.Now)
                throw new Exception("Siamo spiacenti l'evento è terminato");

            if (this.ReservedSeats < seats)
                throw new Exception($"Non è possibile disdire {seats} {(seats ==1 ? "prenotazione" : "prenotazioni")}");

            this.ReservedSeats = this.ReservedSeats - seats;
        }

        public override string ToString()
        {
            return $"\nEvento:\n\t{this.Data.ToString("dd/MM/yyyy")} -Titolo: {this.Title}\n";
        }


    }
}
