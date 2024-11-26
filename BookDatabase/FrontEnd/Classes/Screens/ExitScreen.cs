using BookDatabase.FrontEnd.Classes.Components;
using BookDatabase.FrontEnd.Classes.Interfaces;

namespace BookDatabase.FrontEnd.Classes.Screens
{
	internal class ExitScreen : MenuScreen<ExitScreen>, IScreen
	{
		internal override string Title { get; }  = $"Exit The Library";
		internal override string Prompt { get; } = $"Are you sure you want to exit the application?";
		internal override List<string> Options { get; } = ["No, Return to Main Menu", "Yes, Exit The Application"];
		internal override List<Action> Navigation { get; } = [HomeScreen.Open, HomeScreen.Open, ExitScreen.Exit];

		static void Exit() => Environment.Exit(0);
	}
}
