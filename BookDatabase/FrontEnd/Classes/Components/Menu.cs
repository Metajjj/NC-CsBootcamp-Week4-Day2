using static System.Console;

namespace BookDatabase.FrontEnd.Classes.Components
{
	internal static class Menu
	{
		/// <summary>
		/// Returns an int based on the index of the option selected, returns -1 if user selects "Back".
		/// </summary>
		/// <param name="prompt">The message to display to the user.</param>
		/// <param name="options">A List of strings representing the options to display.</param>
		/// <returns><c>int</c> The index of selected option or, -1 if "Back" selected.</returns>
		internal static int GetSelection(string prompt, List<string> options)
		{
			Clear();

			int currentIndex = 0;

			while (true)
			{
				WriteLine(prompt + Environment.NewLine);

				RenderOptions(options, currentIndex);

				RenderKeyOptions();

				ConsoleKey key = GetKeySelection();

				if (key == ConsoleKey.Enter) return currentIndex;
				if (key == ConsoleKey.Backspace) return -1;

				currentIndex = UpdateCurrentIndex(key, currentIndex, options.Count);

				Clear();
			}
		}

		private static ConsoleKey GetKeySelection()
		{
			ConsoleKey key = ConsoleKey.None;
			while (key == ConsoleKey.None)
			{
				var input = ReadKey(true).Key;
				switch (input)
				{
					case ConsoleKey.Enter:
					case ConsoleKey.Backspace:
					case ConsoleKey.UpArrow:
					case ConsoleKey.DownArrow:
						key = input;
						break;
				}
			}
			return key;
		}

		private static int UpdateCurrentIndex(ConsoleKey key, int currentIndex, int optionsCount)
		{
			if (key == ConsoleKey.UpArrow)
			{
				currentIndex = currentIndex == 0
					? optionsCount - 1
					: currentIndex - 1;
			}

			if (key == ConsoleKey.DownArrow)
			{
				currentIndex = currentIndex == optionsCount - 1
					? 0
					: currentIndex + 1;
			}

			return currentIndex;
		}

		private static void RenderOptions(List<string> options, int currentIndex)
		{
			for (int i = 0; i < options.Count; i++)
			{
				if (i != currentIndex)
				{
					WriteLine($">  {options[i]}");
				}
				else
				{
					InvertColours();
					WriteLine($">  {options[i]}");
					InvertColours();
				}
			}
		}

		private static void InvertColours()
		{
			BackgroundColor = BackgroundColor == ConsoleColor.Black ? ConsoleColor.White : ConsoleColor.Black;
			ForegroundColor = ForegroundColor == ConsoleColor.Black ? ConsoleColor.White : ConsoleColor.Black;
		}

		private static void RenderKeyOptions() => WriteLine(@"


[ UP ]        - Navigate up.
[ DOWN ]      - Navigate down.
[ ENTER ]     - Select option.
[ BACKSPACE ] - Back to Previous Menu.");
	}
}
