using csharp_gestore_eventi.Classes;

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
                //add event
                Console.WriteLine($"Evento {eventGenerated + 1}/{eventsNumber}");
                Console.WriteLine("Inserire Titolo");
                eventTitle = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("Inserire data 21/12/2000");
                eventData = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Inserire posti disponibili");
                eventCapacity = int.Parse(Console.ReadLine());
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
                Console.WriteLine();
            }

            Console.WriteLine($"\nNel programma sono presenti {program1.GetEventsNumber()} eventi");
            Console.WriteLine($"\n{program1}");

            //sort by date
            Console.WriteLine($"\nProva a ricercare un evento tramite data: (es. dd/MM/yyyy)");
            string dateChoice = Console.ReadLine();
            program1.GetEventByDate(dateChoice);

            program1.DeleteList();

        }
    }
}