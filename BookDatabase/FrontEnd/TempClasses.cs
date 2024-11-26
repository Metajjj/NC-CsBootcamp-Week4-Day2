using System.Globalization;
using BookDatabase.BackEnd.Books;
using BookDatabase.FrontEnd.Classes.Interfaces;

namespace BookDatabase.FrontEnd
{
	public class BookService : IBookService
	{
		private List<Book> _books =
		[
			new (1, "Wind in the Willows", "1.1", DateTime.ParseExact("10/08/1935", "MM/dd/yyyy", CultureInfo.InvariantCulture)),
			new (2, "To Kill a Mockingbird", "2.3", DateTime.ParseExact("07/11/1960", "MM/dd/yyyy", CultureInfo.InvariantCulture)),
			new (3, "1984", "3.7", DateTime.ParseExact("06/08/1949", "MM/dd/yyyy", CultureInfo.InvariantCulture)),
			new (4, "Pride and Prejudice", "4.2", DateTime.ParseExact("01/28/1813", "MM/dd/yyyy", CultureInfo.InvariantCulture)),
			new (5, "The Great Gatsby", "5.6", DateTime.ParseExact("04/10/1925", "MM/dd/yyyy", CultureInfo.InvariantCulture)),
			new (6, "Moby-Dick", "6.4", DateTime.ParseExact("11/14/1851", "MM/dd/yyyy", CultureInfo.InvariantCulture)),
			new (7, "The Catcher in the Rye", "7.8", DateTime.ParseExact("07/16/1951", "MM/dd/yyyy", CultureInfo.InvariantCulture)),
			new (8, "Jane Eyre", "8.5", DateTime.ParseExact("10/16/1847", "MM/dd/yyyy", CultureInfo.InvariantCulture)),
			new (9, "The Hobbit", "9.9", DateTime.ParseExact("09/21/1937", "MM/dd/yyyy", CultureInfo.InvariantCulture)),
		];

		public List<Book> GetBooks(List<Predicate<Book>> filters) => _books.Where(book => filters.All(filter => filter(book))).ToList();

		public Book? GetBookById(int id) => _books.FirstOrDefault(b => b.ID == id);

		public void DeleteBook(Book book) => _books.Remove(book);

		public Book EditBook(Book oldBook, Book newBook)
		{
			_books.Remove(oldBook);
			_books.Add(newBook);
			return newBook;
		}
	}

	public static class BookExtensions
	{
		public static string GetSummary(this Book book)
		{
return $@"{"Id:",-20}{book.ID}

{"Name:",-20}{book.Name}

{"Released:",-20}{book.ReleaseDate:dd-MM-yyyy}

{"Location:",-20}{book.Location}";
		}
	}
}
