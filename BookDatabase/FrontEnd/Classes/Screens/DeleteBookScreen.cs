using BookDatabase.FrontEnd.Classes.Components;
using BookDatabase.FrontEnd.Classes.Interfaces;
using BookDatabase.FrontEnd.Classes.Screens.SuperClasses;
using BookDatabase.FrontEnd.Services;

namespace BookDatabase.FrontEnd.Classes.Screens
{
	internal class DeleteBookScreen(IBookService bookService): MenuScreen<DeleteBookScreen>, IScreen
	{
		private readonly IBookService _bookService = bookService;
		internal override string Title { get; set; } = "DELETE BOOK";
		internal override string Prompt { get; set; } = string.Empty;
		internal override List<string> Options { get; set; } = ["No, Return To Book List", "Yes, Delete This Book"];
		internal override List<Action> Navigation { get; set; } = [BookListScreen.Open, BookListScreen.Open, BookListScreen.Open];

		public override void Run()
		{
			Prompt = App.SelectedBook!.GetSummary() + "\n\nAre you sure you want to delete this book?";
			int selection = Menu.GetSelection(Title, Prompt, Options);

			if (selection == 1)
			{
				_bookService.DeleteBook(App.SelectedBook!);
				App.SelectedBook = null;
			}

            Navigation[selection].Invoke();
		}
	}
}
