using csharp_gestore_eventi.Classes;
using csharp_gestore_eventi.Classes.Event;

namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Program variables
            string programTitle = "";


            //Event variables
            string eventTitle = "";
            string eventData = "";
            int eventCapacity = 0;

            //Conference variables
            string speakerInfo = "";
            double conferencePrice = 0;

            Console.WriteLine("Benvenuto al tuo gestionale eventi!!!\n");

            //add program
            Console.WriteLine("Aggiungere il titolo al nuovo programma\n");
            programTitle = Console.ReadLine();

            ProgramEvent program1 = new ProgramEvent(programTitle);

            //add events
            Console.WriteLine("Insereire il numero di eventi da aggiungere");
            int eventsNumber = int.Parse(Console.ReadLine());
            int eventGenerated = 0;

            while (eventGenerated < eventsNumber)
            {
                //controll the type of the events
                Console.WriteLine($"Il tuo evento è una conferenza? si/no: ");
                string isConference = Console.ReadLine();

                //add event
                Console.WriteLine($"Evento {eventGenerated + 1}/{eventsNumber}");
                Console.WriteLine("Inserire Titolo");
                eventTitle = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("Inserire data dd/MM/yyyy");
                eventData = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Inserire posti disponibili");
                eventCapacity = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (isConference == "si")
                {
                    Console.WriteLine("Inserire dati relatore");
                    speakerInfo = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Inserire prezzo");
                    conferencePrice = double.Parse(Console.ReadLine());
                    Console.WriteLine();
                    try
                    {
                        Event event1 = new Event_Conference(eventTitle, eventData, eventCapacity, speakerInfo, conferencePrice);
                        program1.SetEventList(event1);
                        eventGenerated++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        Console.WriteLine();
                    }
                }
                else
                {
                    try
                    {
                        Event event1 = new Event(eventTitle, eventData, eventCapacity);
                        program1.SetEventList(event1);
                        eventGenerated++;
                    }
                    catch(Exception ex) 
                    { 
                        Console.WriteLine(ex.ToString());
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine($"\nNel programma sono presenti {program1.GetEventsNumber()} eventi");
            Console.WriteLine($"\n{program1}");

            //sort by date
            Console.WriteLine($"\nProva a ricercare un evento tramite data: (es. dd/MM/yyyy)");
            string dateChoice = Console.ReadLine();
            List<Event> datedEvent = program1.GetEventsByDate(dateChoice);
            ProgramEvent.PrintEventFromList(datedEvent);
            program1.DeleteList();

        }
    }
}