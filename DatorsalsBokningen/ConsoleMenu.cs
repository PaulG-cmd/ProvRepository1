using DatorsalsBokningen.Models;
using System;
using System.Diagnostics;

namespace DatorsalsBokningen
{
    internal class ConsoleMenu
    {
        private readonly BookingService _bookingService;

        public ConsoleMenu(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public void ShowGraphic()
        {
            Console.WriteLine(" ______________");
            Console.WriteLine("||            ||");
            Console.WriteLine("||            ||");
            Console.WriteLine("||            ||");
            Console.WriteLine("||            ||");
            Console.WriteLine("||____________||");
            Console.WriteLine("|______________|");
            Console.WriteLine(" \\############\\");
            Console.WriteLine("  \\############\\");
            Console.WriteLine("   \\     ____   \\");
            Console.WriteLine("    \\___\\___\\___\\");
            Console.WriteLine("");
        }

        public void Run()
        {
            bool running = true;
            ShowGraphic();

            while (running)
            {
                PrintMenu();
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ShowBookings();
                        break;
                    case 2:
                        CreateBooking();
                        break;
                    case 3:
                        EditBooking();
                        break;
                    case 4:
                        CancelBooking();
                        break;
                    case 5:
                        running = false;
                        break;
                    default:
                        Debug.Print("Ogiltigt val.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine();
                    Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                    Console.ReadKey();
                    Console.ReadLine();
                }
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine("=== Datorsalsbokningen ==");
            Console.WriteLine();
            Console.WriteLine("1. Visa bokningar");
            Console.WriteLine("2. Skapa bokning");
            Console.WriteLine("3. Redigera bokning");
            Console.WriteLine("4. Avboka bokning");
            Console.WriteLine("5. Avsluta");
            Console.WriteLine();
            Console.Write("Välj: ");
        }

        private void ShowBookings()
        {
            Console.WriteLine();
            Console.WriteLine("=== Bokningar ===");

            foreach (Booking booking in _bookingService.GetAllBookings())
            {
                Console.WriteLine(
                    $"{booking.Id}. {booking.StartTime:HH:mm}-{booking.EndTime:HH:mm} | " +
                    $"{booking.Name} | {booking.Purpose}");
            }
        }

        private void CreateBooking()
        {
            Console.Write("Namn: ");
            string name = Console.ReadLine();

            Console.Write("Starttid (HH:mm): ");
            DateTime startTime = DateTime.Parse(Console.ReadLine());

            Console.Write("Sluttid (HH:mm): ");
            DateTime EndTime = DateTime.Parse(Console.ReadLine());

            Console.Write("Ändamål: ");
            string purpose = Console.ReadLine();

            Booking booking = _bookingService.CreateBooking(name, startTime, EndTime, purpose);
            Console.WriteLine($"Bokning {booking.Id} skapades.");
        }

        private void EditBooking()
        {
            ShowBookings();

            Console.Write("ID på bokningen som ska redigeras: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nytt namn: ");
            string name = Console.ReadLine();

            Console.Write("Ny starttid (HH:mm): ");
            DateTime StartTime = DateTime.Parse(Console.ReadLine());

            Console.Write("Ny sluttid (HH:mm): ");
            DateTime endTime = DateTime.Parse(Console.ReadLine());

            Console.Write("Nytt ändamål: ");
            string purpose = Console.ReadLine();

            _bookingService.EditBooking(id, name, StartTime, endTime, purpose);
            Console.WriteLine("Bokningen uppdaterades.");
        }

        private void CancelBooking()
        {
            ShowBookings();

            Console.Write("ID på bokningen som ska avbokas: ");
            int id = int.Parse(Console.ReadLine());

            _bookingService.CancelBooking(id);
            Console.WriteLine("Bokningen avbokades.");
        }
    }
}