using BookDatabase.FrontEnd.Classes.Interfaces;

namespace BookDatabase.FrontEnd.Classes.Screens
{
	internal class BrowseBooksMenuScreen : MenuScreen<BrowseBooksMenuScreen>, IScreen
	{
		internal override string Title { get; }  = $"All Books";
		internal override string Prompt { get; } = $"Here is a list of all books:";
		internal override List<string> Options { get; } = ["Home"];
		internal override List<Action> Navigation { get; } = [MainMenuScreen.Open, MainMenuScreen.Open];
	}
}
