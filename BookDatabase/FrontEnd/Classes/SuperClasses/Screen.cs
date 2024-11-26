namespace BookDatabase.FrontEnd.Classes.SuperClasses
{
	internal abstract class Screen
	{
		private readonly Type _screenType;

        protected Screen(Type screenType)
        {
            if (typeof(Screen).IsAssignableFrom(screenType)) _screenType = screenType;

            else throw new ApplicationException($"An invalid screen type has been created as implementing Screen: {screenType.GetType().FullName}.");
        }

        internal void Load(Type screenType)
		{
			if (screenType == _screenType) Run();
		}

		internal abstract void Run();
	}
}
