using BookDatabase.FrontEnd.Classes.Components;
using BookDatabase.FrontEnd.Classes.SuperClasses;

namespace BookDatabase.FrontEnd.Classes.Screens
{
	internal class HomeScreen() : Screen(typeof(HomeScreen))
	{
		private static readonly string prompt = $"Welcome to LIBRARY!";
		private static readonly List<string> options = ["1", "2", "3", "4"];
		private static readonly List<string> navigation = ["Back", "1stScreen", "2ndScreen", "3"];


		internal override void Run()
		{
            int selection = Menu.GetSelection("Select an option", ["1", "2", "3"]);
            Console.WriteLine($"User selected {selection}");
			Console.ReadKey(true);
		}
	}
}
