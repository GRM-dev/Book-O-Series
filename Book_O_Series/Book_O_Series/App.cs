using Book_O_Series.Helpers;
using Book_O_Series.Models;
using Book_O_Series.Services;

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