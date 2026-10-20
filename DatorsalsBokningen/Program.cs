namespace DatorsalsBokningen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookingService bookingService = new BookingService();
            ConsoleMenu menu = new ConsoleMenu(bookingService);
            menu.Run();
        }
    }
}