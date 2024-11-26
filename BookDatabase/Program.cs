using BookDatabase.BackEnd;
using BookDatabase.FrontEnd.Services;

namespace BookDatabase
{
	internal class Program
    {
        static void Main(string[] args)
        {
            App.Run();

            Task.Run(() => { Thread.Sleep(1000 * 30); });
            Console.ReadKey();

        }
    }
}
