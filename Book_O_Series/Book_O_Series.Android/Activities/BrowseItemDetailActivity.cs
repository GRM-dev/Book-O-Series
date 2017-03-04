using Android.App;
using Android.OS;
using Android.Widget;
using Book_O_Series.Models;
using Book_O_Series.ViewModels;

namespace Book_O_Series.Droid.Activities
{
    [Activity(Label = "Details", ParentActivity = typeof(MainActivity))]
    [MetaData("android.support.PARENT_ACTIVITY", Value = ".MainActivity")]
    public class BrowseItemDetailActivity : BaseActivity
    {
        private ItemDetailViewModel _viewModel;
        private Spinner _spinner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var data = Intent.GetStringExtra("data");

            var item = Newtonsoft.Json.JsonConvert.DeserializeObject<Item>(data);
            _viewModel = new ItemDetailViewModel(item);

            FindViewById<TextView>(Resource.Id.description).Text = item.Description;


            SupportActionBar.Title = item.Text;
        }

        protected override void OnStart()
        {
            base.OnStart();
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;

        }

        protected override void OnStop()
        {
            base.OnStop();
            _viewModel.PropertyChanged -= ViewModel_PropertyChanged;
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }

        /// <summary>
        /// Specify the layout to inflace
        /// </summary>
        protected override int LayoutResource => Resource.Layout.activity_item_details;
    }
}