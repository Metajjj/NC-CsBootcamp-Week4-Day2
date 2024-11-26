using BookDatabase.BackEnd.Books;
using BookDatabase.FrontEnd.Classes.Components;
using BookDatabase.FrontEnd.Classes.Interfaces;
using BookDatabase.FrontEnd.Classes.Screens.SuperClasses;
using BookDatabase.FrontEnd.Services;

namespace BookDatabase.FrontEnd.Classes.Screens
{
	internal class BookListScreen(IBookService bookService) : MenuScreen<BookListScreen>, IScreen
	{
		private readonly IBookService _bookService = bookService;
		internal List<Predicate<Book>> Filters { get; set; } = [];
		internal override string Title { get; set; } = $"Book List";
		internal override string Prompt { get; set; } = string.Empty;
		internal override List<string> Options { get; set; } = [];
		internal override List<Action> Navigation { get; set; } = [MainMenuScreen.Open];

		public override void Run()
		{
			Options.Clear();
			Prompt = "Books ";
			if (Filters.Count != 0) Filters.ForEach(f => Prompt += $"{f}");

			Prompt += ":";

			List<Book> books = _bookService.GetBooks(Filters);

			foreach (var book in books)
			{
				Options.Add(book.Name);
				Navigation.Add(BookDetailsScreen.Open);
			}

			int selection = Menu.GetSelection(Title, Prompt, Options);

			if (selection == 0 || selection == Options.Count - 1) Filters.Clear();

			else App.SelectedBook = books[selection - 1];

			Navigation[selection].Invoke();
		}
	}
}
