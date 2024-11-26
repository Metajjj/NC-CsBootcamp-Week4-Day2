using BookDatabase.FrontEnd.Services;

namespace BookDatabase.FrontEnd.Classes.Interfaces
{
	public interface IScreen
	{
		public Type _screenType { get; }
		public void Load(Type screenType)
		{
			if (screenType == _screenType) Run();
		}

		public abstract void Run();
	}
}
