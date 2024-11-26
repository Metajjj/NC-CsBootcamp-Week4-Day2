using BookDatabase.FrontEnd.Classes.Interfaces;
using BookDatabase.FrontEnd.Services;

namespace BookDatabase.FrontEnd.Classes.Screens.SuperClasses
{
    public abstract class Screen<T> : IScreen
    {
        internal static void Open()
        {
            App.LoadScreen(typeof(T));
        }

        public Type _screenType => typeof(T);

        internal void Load(Type screenType)
        {
            if (screenType == _screenType) Run();
        }

        public abstract void Run();
    }
}
