using BookDatabase.FrontEnd.Classes.Components;
using BookDatabase.FrontEnd.Classes.Interfaces;
using BookDatabase.FrontEnd.Classes.Screens.SuperClasses;

namespace BookDatabase.FrontEnd.Classes.Screens
{
    internal class ExitMenuScreen : MenuScreen<ExitMenuScreen>, IScreen
	{
		internal override string Title { get; set; }  = $"Exit The Library";
		internal override string Prompt { get; set; } = $"Are you sure you want to exit the application?";
		internal override List<string> Options { get; set; } = ["No, Return to Main Menu", "Yes, Exit The Application"];
		internal override List<Action> Navigation { get; set; } = [MainMenuScreen.Open, MainMenuScreen.Open, ExitMenuScreen.Exit];

		static void Exit() => Environment.Exit(0);
	}
}
