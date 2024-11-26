using BookDatabase.BackEnd.Books;
using BookDatabase.FrontEnd.Classes.Interfaces;
using BookDatabase.FrontEnd.Classes.Screens;
using Microsoft.Extensions.DependencyInjection;

namespace BookDatabase.FrontEnd.Services
{
	internal static class App
	{
		private static event Action<Type> loadScreen;
		public static void LoadScreen(Type screenType) => loadScreen?.Invoke(screenType);
		public static Book? SelectedBook { get; set; } = null;

		public static void Run()
		{
			var serviceProvider = new ServiceCollection()
				.AddSingleton<IBookService, BookService>()
				.AddSingleton<IScreen, MainMenuScreen>()
				.AddSingleton<IScreen, ExitMenuScreen>()
				.AddSingleton<IScreen, BrowseBooksMenuScreen>()
				.AddSingleton<IScreen, BookListScreen>()
				.AddSingleton<IScreen, BookDetailsScreen>()
				.AddSingleton<IScreen, DeleteBookScreen>()
				.AddSingleton<IScreen, EditBookScreen>()
				.BuildServiceProvider();

			var screens = serviceProvider.GetServices<IScreen>().ToList();
			screens.ForEach(s => loadScreen += s.Load);

			MainMenuScreen.Open();
		}
	}
}
