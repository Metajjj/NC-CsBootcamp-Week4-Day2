using BookDatabase.FrontEnd.Classes.Interfaces;
using BookDatabase.FrontEnd.Classes.Screens.SuperClasses;

namespace BookDatabase.FrontEnd.Classes.Screens
{
    internal class MainMenuScreen : MenuScreen<MainMenuScreen>, IScreen
	{
		internal override string Title { get; set; }  = $"The Library";
		internal override string Prompt { get; set; } = $"Welcome to the library, what would you like to do?";
		internal override List<string> Options { get; set; } = ["Browse Books", "Exit The Library"];
		internal override List<Action> Navigation { get; set; } = [ExitMenuScreen.Open, BrowseBooksMenuScreen.Open, ExitMenuScreen.Open];
	}
}
