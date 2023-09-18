﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace csharp_gestore_eventi.Classes
{
    public class ProgramEvent
    {
        public string Title { get; private set; }
        public List<Event> EventList { get; private set;}

        public ProgramEvent(string title)
        {
            this.Title = title;
            this.EventList = new List<Event>();
        }

        //**********************METHODS

        /// <summary>
        /// Add an event in the Program list
        /// </summary>
        /// <param name="item">Event to add</param>
        public void SetEventList(Event item)
        {
            this.EventList.Add(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date">dd/MM/yyyy</param>
        public void GetEventByDate(string date)
        {
            DateTime eventDate = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            foreach (var item in this.EventList)
            {
                if(item.Date == eventDate)
                    Console.WriteLine(item);
            }
        }

        public void DeleteList()
        {
            this.EventList?.Clear();
        }

        public int GetEventsNumber()
        {
            return this.EventList.Count;
        }

        public static void GetEventFromList(List<Event> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public override string ToString()
        {
            string message="";
            foreach (var item in this.EventList)
            {
                message += $"\n\t {item.Date.ToString("dd/MM/yyyy")} -{item.Title}";
            }
            return $"{this.Title}:{message}";
        }
    }
}
