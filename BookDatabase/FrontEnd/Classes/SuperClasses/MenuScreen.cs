using BookDatabase.FrontEnd.Classes.Components;
using BookDatabase.FrontEnd.Classes.Interfaces;
using BookDatabase.FrontEnd.Classes.SuperClasses;

namespace BookDatabase.FrontEnd.Classes.Screens
{
	internal abstract class MenuScreen<T>() : Screen<T> where T : IScreen
	{
		internal abstract string Title { get; }
		internal abstract string Prompt { get; }
		internal abstract List<string> Options { get; }
		internal abstract List<Action> Navigation { get; }

		public override void Run()
		{
            int selection = Menu.GetSelection(Title, Prompt, Options);
            Navigation[selection].Invoke();
		}
	}
}
