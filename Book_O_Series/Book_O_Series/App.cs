using Book_O_Series.Helpers;
using Book_O_Series.Interfaces;
using Book_O_Series.Services;
using Book_O_Series.Model;

namespace Book_O_Series
{
    public partial class App
    {
        public App()
        {
        }

        public static void Initialize()
        {
            ServiceLocator.Instance.Register<IDataStore<Item>, MockDataStore>();
        }
    }
}