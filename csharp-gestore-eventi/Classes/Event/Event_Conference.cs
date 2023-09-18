using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi.Classes.Event
{


    public class Event_Conference : Event
    {

        public string Speaker { get; private set; }
        public double Price {  get ; private set; }

        public Event_Conference(string title, string date, int maxCapacity, string speaker, double price) : base(title, date, maxCapacity)
        {
            this.Speaker = speaker;
            this.Price = price;
        }

        public override string ToString()
        {
            return $"\t{this.Date.ToString("dd/MM/yyyy")} - {this.Title} - {this.Speaker} - {this.GetFormattedPrice()}\n";
        }

        public string GetFormattedPrice()
        {
            return $"{this.Price.ToString("0.00")}Euro";
        } 
    }
}
