namespace BookDatabase.FrontEnd.Classes.Components
{
	internal static class TextField
	{
		internal static string GetInput(string title, string prompt)
		{
			Console.Clear();

			Console.WriteLine($"{title}\n{new string('=', title.Length)}\n\n{prompt}\n\n");

			string? value = Console.ReadLine();

			if (string.IsNullOrEmpty(value))
			{
				Console.WriteLine("Please enter a valid input.");
				value = GetInput(title, prompt);
			}

			return value;
		}
	}
}
