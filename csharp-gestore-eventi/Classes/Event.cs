using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi.Classes
{
    internal class Event
    {
        private string _Title; 
        private DateTime _Data;
        private int _MaxCapacity;

        public string Title {
            get 
            {
                return _Title;
                }
            set 
            {
                if (value != "")
                    this._Title = value;
                else
                    throw new Exception("Inserire un Titolo valido");
            } 
        }
        public DateTime Data { 
            get { return _Data; }
            set { 
                if( value > DateTime.Now)
                    this._Data = value;
                else
                    throw new Exception("Inserire una data valida");
            }
        }
        public int MaxCapacity { 
            get { return _MaxCapacity; }
            private set 
            {
                if (value > 0)
                    this._MaxCapacity = value;
                else
                    throw new Exception("Inserire una capienza maggiore di 0");
            } 
        }
        public int ReservedSeats { get; private set; }

        public Event(string title, string data, int maxCapacity)
        {
            this.Title = title;
            this.Data = DateTime.Parse(data);
            this.MaxCapacity = maxCapacity;
            this.ReservedSeats = 0;
        }


        //***************************************METHODS

        public void ReservePlace(int n)
        {
            if (this.Data < DateTime.Now)
                throw new Exception("Siamo spiacenti l'evento è terminato");

            if (this.MaxCapacity < this.ReservedSeats + n)
                throw new Exception($"Restano {this.MaxCapacity - this.ReservedSeats} disponibili");

            this.ReservedSeats = this.ReservedSeats + n;
        }

        public void CancelReservation(int n)
        {
            if (this.Data < DateTime.Now)
                throw new Exception("Siamo spiacenti l'evento è terminato");

            if (this.ReservedSeats < n)
                throw new Exception($"Non è possibile disdire {n} {(n ==1 ? "prenotazione" : "prenotazioni")}");

            this.ReservedSeats = this.ReservedSeats - n;
        }

        public override string ToString()
        {
            return $"\nEvento:\n\t\t{this.Data.ToString("dd/MM/yyyy")} -Titolo {this.Title}\n";
        }


    }
}
