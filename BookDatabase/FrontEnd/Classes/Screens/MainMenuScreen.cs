using BookDatabase.FrontEnd.Classes.Interfaces;

namespace BookDatabase.FrontEnd.Classes.Screens
{
	internal class MainMenuScreen : MenuScreen<MainMenuScreen>, IScreen
	{
		internal override string Title { get; }  = $"The Library";
		internal override string Prompt { get; } = $"Welcome to the library, what would you like to do?";
		internal override List<string> Options { get; } = ["Browse Books", "Exit The Library"];
		internal override List<Action> Navigation { get; } = [ExitMenuScreen.Open, BrowseBooksMenuScreen.Open, ExitMenuScreen.Open];
	}
}
