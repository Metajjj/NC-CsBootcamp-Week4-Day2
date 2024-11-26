using BookDatabase.BackEnd.Books;
using BookDatabase.FrontEnd.Classes.Components;
using BookDatabase.FrontEnd.Classes.Interfaces;
using BookDatabase.FrontEnd.Classes.Screens.SuperClasses;
using BookDatabase.FrontEnd.Services;

namespace BookDatabase.FrontEnd.Classes.Screens
{
    internal class BrowseBooksMenuScreen : MenuScreen<BrowseBooksMenuScreen>, IScreen
	{
		internal override string Title { get; set; }  = $"Browse Books";
		internal override string Prompt { get; set; } = $"What books would you like to browse?";
		internal override List<string> Options { get; set; } = ["All Books", "Filter Books", "Back to Main Menu"];
		internal override List<Action> Navigation { get; set; } = [MainMenuScreen.Open, BookListScreen.Open, BrowseBooksMenuScreen.Open];
	}
}
