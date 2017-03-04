using System;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Widget;
using Book_O_Series.Helpers;
using Book_O_Series.Models;
using Book_O_Series.ViewModels;

namespace Book_O_Series.Droid.Activities
{

    [Activity(Label = "AddItemActivity")]
    public class AddItemActivity : Activity
    {
        private FloatingActionButton _saveButton;
        private EditText _title, _description;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_add_item);
            _saveButton = FindViewById<FloatingActionButton>(Resource.Id.save_button);
            _title = FindViewById<EditText>(Resource.Id.txtTitle);
            _description = FindViewById<EditText>(Resource.Id.txtDesc);

            _saveButton.Click += SaveButton_Click;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var item = new Item
            {
                Text = _title.Text,
                Description = _description.Text
            };

            MessagingCenter.Send(this, "AddItem", item);
            Finish();
        }

        public Item Item { get; set; }
        public ItemsViewModel ViewModel { get; set; }
        public BaseViewModel BaseModel { get; set; }
    }
}
