using BookDatabase.FrontEnd.Classes.Screens;
using BookDatabase.FrontEnd.Classes.SuperClasses;
using Microsoft.Extensions.DependencyInjection;

namespace BookDatabase.FrontEnd.Services
{
	internal static class App
	{
		private static event Action<Type> loadScreen;
		public static void LoadScreen(string screenName)
		{
			Type screenType = TryConvertToScreenType(screenName);
			loadScreen?.Invoke(screenType);
		}

		public static Book? ActiveBook { get; private set; }

		public static void Run()
		{
			var serviceProvider = new ServiceCollection()
				.AddSingleton<Screen, HomeScreen>()
				.BuildServiceProvider();

			var screens = serviceProvider.GetServices<Screen>().ToList();
			screens.ForEach(s => loadScreen += s.Load);

			LoadScreen("HomeScreen");
		}

		private static Type TryConvertToScreenType(string screenTypeName)
		{
			Type screenType = Type.GetType($"BookDatabase.FrontEnd.Classes.Screens.{screenTypeName}");

			if (screenType is null) throw new ApplicationException($"'{screenTypeName}' is an invalid screen name.");

			return screenType;
		}
	}
}
