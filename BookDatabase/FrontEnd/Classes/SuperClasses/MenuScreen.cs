using BookDatabase.FrontEnd.Classes.Components;
using BookDatabase.FrontEnd.Classes.Interfaces;
using BookDatabase.FrontEnd.Classes.SuperClasses;

namespace BookDatabase.FrontEnd.Classes.Screens
{
	internal abstract class MenuScreen<T>() : Screen<T> where T : IScreen
	{
		/// <summary>
		/// Title of the screen.
		/// </summary>
		internal abstract string Title { get; }

		/// <summary>
		/// Prompt to provide for selection.
		/// </summary>
		internal abstract string Prompt { get; }

		/// <summary>
		/// A list of strings representing the options available for user selection. Options should contain one fewer element than <see cref="Navigation"/>.
		/// </summary>
		internal abstract List<string> Options { get; }

		/// <summary>
		/// A list of actions where element 0 represents the user selecting "BACK". Navigation should have one more element than <see cref="Options"/> as a result.
		/// </summary>
		internal abstract List<Action> Navigation { get; }

		public override void Run()
		{
            int selection = Menu.GetSelection(Title, Prompt, Options);
            Navigation[selection].Invoke();
		}
	}
}
