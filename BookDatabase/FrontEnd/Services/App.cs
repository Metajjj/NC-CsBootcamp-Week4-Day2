using BookDatabase.FrontEnd.Classes.Interfaces;
using BookDatabase.FrontEnd.Classes.Screens;
using Microsoft.Extensions.DependencyInjection;

namespace BookDatabase.FrontEnd.Services
{
	internal static class App
	{
		private static event Action<Type> loadScreen;
		public static void LoadScreen(Type screenType) => loadScreen?.Invoke(screenType);

		public static Book? ActiveBook { get; private set; }

		public static void Run()
		{
			var serviceProvider = new ServiceCollection()
				.AddSingleton<IScreen, HomeScreen>()
				.AddSingleton<IScreen, ExitScreen>()
				.AddSingleton<IScreen, BrowseBooksScreen>()
				.BuildServiceProvider();

			var screens = serviceProvider.GetServices<IScreen>().ToList();
			screens.ForEach(s => loadScreen += s.Load);

			HomeScreen.Open();
		}
	}
}
