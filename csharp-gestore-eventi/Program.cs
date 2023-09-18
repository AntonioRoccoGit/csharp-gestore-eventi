using csharp_gestore_eventi.Classes;

namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string eventTitle = "";
            string eventData = "";
            int eventCapacity = 0;

            //add program
            ProgramEvent program1 = new ProgramEvent("Ferragosto 2024");

            //add event
            Console.WriteLine("Benvenuto al tuo gestionale eventi!!!");
            Console.WriteLine();
            Console.WriteLine("Inserire Titolo per un nuovo evento");
            eventTitle = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Inserire data per il nuovo evento");
            eventData = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Inserire sedute massime per il nuovo evento");
            eventCapacity = int.Parse(Console.ReadLine());

            Event event1 = new Event(eventTitle, eventData, eventCapacity);
            Console.WriteLine();

            Console.WriteLine("Riepilogo evento");
            Console.WriteLine(event1);

            program1.SetEventList(event1);
            Console.WriteLine(program1);

            Console.WriteLine("Desidera effettuare una prentoazione?  si/no");
            string choice = Console.ReadLine();

            if(choice == "si")
            {
                Console.WriteLine("Inserire numeo persone");
                int seatNumber = int.Parse(Console.ReadLine());
                event1.ReservePlace(seatNumber);
            }

            string wantCancel;
         
            Console.WriteLine($"Posti rimanenti: {event1.MaxCapacity - event1.ReservedSeats}\nTotale Biglietti Venduti: {event1.ReservedSeats}\n");
            Console.WriteLine($"Disdire prenotazioni? si/no\n");
            wantCancel = Console.ReadLine();

            while (wantCancel == "si")
            {
                Console.WriteLine($"Quante sedute cancellare?\n");
                int cancelledSeat = int.Parse(Console.ReadLine());
                Console.WriteLine();
                event1.CancelReservation(cancelledSeat);

                Console.WriteLine($"Posti rimanenti: {event1.MaxCapacity - event1.ReservedSeats}\nTotale Biglietti Venduti: {event1.ReservedSeats}\n");
                Console.WriteLine($"Continuare a disdire prenotazioni? si/no\n");
                wantCancel = Console.ReadLine();
            }






            

        }
    }
}