using BookDatabase.BackEnd;
using BookDatabase.BackEnd.Books;

namespace BookDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var b = DatabaseHandler.getDB().AccessBookHandler();

            b.AddBook("name","loc");

            Task.Run(() => { Thread.Sleep(1000 * 30); });
            Console.ReadKey();

        }
    }
}
