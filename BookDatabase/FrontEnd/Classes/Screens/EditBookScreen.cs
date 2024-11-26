using BookDatabase.BackEnd.Books;
using BookDatabase.FrontEnd.Classes.Components;
using BookDatabase.FrontEnd.Classes.Interfaces;
using BookDatabase.FrontEnd.Classes.Screens.SuperClasses;
using BookDatabase.FrontEnd.Services;

namespace BookDatabase.FrontEnd.Classes.Screens
{
	internal class EditBookScreen(IBookService bookService) : MenuScreen<EditBookScreen>, IScreen
	{
		private readonly IBookService _bookService = bookService;
		internal override string Title { get; set; } = "EDIT BOOK";
		internal override string Prompt { get; set; } = string.Empty;
		internal override List<string> Options { get; set; } = ["Book Name", "Book Location", "Book Release Date", "Return to Book List"];
		internal override List<Action> Navigation { get; set; } = [BookListScreen.Open, BookDetailsScreen.Open, BookDetailsScreen.Open, BookDetailsScreen.Open, BookListScreen.Open];

		public override void Run()
		{
			Book selectedBook = App.SelectedBook!;
			Prompt = selectedBook.GetSummary() + "\n\nWhat property would you like to edit?";
			int selection = Menu.GetSelection(Title, Prompt, Options);
			Book? editedBook = null;

			if (selection == 1)
			{
				string newName = TextField.GetInput(Title + "NAME", Prompt = selectedBook.GetSummary() + "\n\nPlease enter a new name:");
				editedBook = selectedBook with { Name = newName }; 
			}

			if (selection == 2)
			{
				string newLocation = TextField.GetInput(Title + "LOCATION", Prompt = selectedBook.GetSummary() + "\n\nPlease enter a new location:");
				editedBook = selectedBook with { Location = newLocation }; 
			}

			if (selection == 3)
			{
				DateTime newReleaseDate = DateField.GetInput(Title + "DATE", Prompt = selectedBook.GetSummary() + "\n\nPlease enter a new release date:");
				editedBook = selectedBook with { ReleaseDate = newReleaseDate };
			}

			if (editedBook != null)
			{
				App.SelectedBook = _bookService.EditBook(selectedBook, editedBook);
			}

            Navigation[selection].Invoke();			
		}
	}
}
