using BookDatabase.FrontEnd.Classes.Components;
using BookDatabase.FrontEnd.Classes.Interfaces;
using BookDatabase.FrontEnd.Classes.Screens.SuperClasses;
using BookDatabase.FrontEnd.Services;

namespace BookDatabase.FrontEnd.Classes.Screens
{
	internal class BookDetailsScreen: MenuScreen<BookDetailsScreen>, IScreen
	{
		internal override string Title { get; set; } = "BOOK DETAILS";
		internal override string Prompt { get; set; } = string.Empty;
		internal override List<string> Options { get; set; } = ["Return to Book List", "Edit Book", "Delete Book"];
		internal override List<Action> Navigation { get; set; } = [MainMenuScreen.Open, BookListScreen.Open, EditBookScreen.Open, DeleteBookScreen.Open];

		public override void Run()
		{
			Prompt = App.SelectedBook!.GetSummary();
			int selection = Menu.GetSelection(Title, Prompt, Options);
            Navigation[selection].Invoke();
		}
	}
}
