using BookDatabase.BackEnd.Books;

namespace BookDatabase.FrontEnd.Classes.Interfaces
{
	public interface IBookService
	{
		public List<Book> GetBooks(List<Predicate<Book>> filters);
		public Book? GetBookById(int id);
		public void DeleteBook(Book book);
		public Book EditBook(Book previousBook, Book newBook);
	}
}
