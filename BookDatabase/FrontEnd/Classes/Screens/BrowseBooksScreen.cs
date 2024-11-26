using BookDatabase.FrontEnd.Classes.Interfaces;

namespace BookDatabase.FrontEnd.Classes.Screens
{
	internal class BrowseBooksScreen : MenuScreen<BrowseBooksScreen>, IScreen
	{
		internal override string Title { get; }  = $"All Books";
		internal override string Prompt { get; } = $"Here is a list of all books:";
		internal override List<string> Options { get; } = ["Home"];
		internal override List<Action> Navigation { get; } = [HomeScreen.Open, HomeScreen.Open];
	}
}
