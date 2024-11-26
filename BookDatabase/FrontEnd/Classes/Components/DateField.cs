namespace BookDatabase.FrontEnd.Classes.Components
{
	internal static class DateField
	{
		internal static DateTime GetInput(string title, string prompt)
		{
			Console.Clear();

			Console.WriteLine($"{title}\n{new string('=', title.Length)}\n\n{prompt}\n\n");

			string? value = Console.ReadLine();

			if (DateTime.TryParse(value, out DateTime newDate))
			{
				return newDate;
			}

			Console.WriteLine("Please enter a valid input.");
			return GetInput(title, prompt);
		}
	}
}
