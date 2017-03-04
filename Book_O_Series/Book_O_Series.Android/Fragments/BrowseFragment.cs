using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Book_O_Series.Droid.Activities;
using Book_O_Series.Droid.Helpers;
using Book_O_Series.Helpers;
using Book_O_Series.Models;
using Book_O_Series.Services;
using Book_O_Series.ViewModels;

namespace Book_O_Series.Droid.Fragments
{
    public class BrowseFragment : Android.Support.V4.App.Fragment, IFragmentVisible
    {
        private BrowseItemsAdapter _adapter;
        private SwipeRefreshLayout _refresher;
        private Task _loadItems;
        private ProgressBar _progress;

        public static BrowseFragment NewInstance() =>
            new BrowseFragment { Arguments = new Bundle() };

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            ServiceLocator.Instance.Register<MockDataStore, MockDataStore>();
            ViewModel = new ItemsViewModel();
            _loadItems = ViewModel.ExecuteLoadItemsCommand();

            MessagingCenter.Subscribe<AddItemActivity, Item>(this, "AddItem", async (obj, item) =>
            {
                await ViewModel.AddItem(item);
            });
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_browse, container, false);
            var recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);

            recyclerView.HasFixedSize = true;
            recyclerView.SetAdapter(_adapter = new BrowseItemsAdapter(Activity, ViewModel));

            _refresher = view.FindViewById<SwipeRefreshLayout>(Resource.Id.refresher);
            _refresher.SetColorSchemeColors(Resource.Color.accent);

            _progress = view.FindViewById<ProgressBar>(Resource.Id.progressbar_loading);
            _progress.Visibility = ViewStates.Gone;

            return view;
        }


        public override void OnStart()
        {
            base.OnStart();
            _refresher.Refresh += Refresher_Refresh;
            _adapter.ItemClick += Adapter_ItemClick;
            if (ViewModel.Items.Count == 0)
            {
                _loadItems.Wait();
            }
        }


        public override void OnStop()
        {
            base.OnStop();
            _refresher.Refresh -= Refresher_Refresh;
            _adapter.ItemClick -= Adapter_ItemClick;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            MessagingCenter.Unsubscribe<AddItemActivity>(this, "AddItem");
        }

        private void Adapter_ItemClick(object sender, RecyclerClickEventArgs e)
        {
            var item = ViewModel.Items[e.Position];
            var intent = new Intent(Activity, typeof(BrowseItemDetailActivity));

            intent.PutExtra("data", Newtonsoft.Json.JsonConvert.SerializeObject(item));
            Activity.StartActivity(intent);
        }

        private async void Refresher_Refresh(object sender, EventArgs e)
        {
            await ViewModel.ExecuteLoadItemsCommand();
            _refresher.Refreshing = false;
        }

        public void BecameVisible()
        {
        }

        public ItemsViewModel ViewModel
        {
            get;
            set;
        }
    }

    public class BrowseItemsAdapter : BaseRecycleViewAdapter
    {
        private ItemsViewModel _viewModel;
        private Activity _activity;

        public BrowseItemsAdapter(Activity activity, ItemsViewModel viewModel)
        {
            this._viewModel = viewModel;
            this._activity = activity;
            this._viewModel.Items.CollectionChanged += (sender, args) =>
            {
                this._activity.RunOnUiThread(NotifyDataSetChanged);
            };
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            //Setup your layout here
            const int id = Resource.Layout.item_browse;
            var itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);
            var vh = new MyViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var item = _viewModel.Items[position];

            // Replace the contents of the view with that element
            var myHolder = holder as MyViewHolder;
            myHolder.TextView.Text = item.Text;
            myHolder.DetailTextView.Text = item.Description;
        }

        public override int ItemCount => _viewModel.Items.Count;
    }

    public class MyViewHolder : RecyclerView.ViewHolder
    {
        public MyViewHolder(View itemView, Action<RecyclerClickEventArgs> clickListener,
            Action<RecyclerClickEventArgs> longClickListener) : base(itemView)
        {
            TextView = itemView.FindViewById<TextView>(Android.Resource.Id.Text1);
            DetailTextView = itemView.FindViewById<TextView>(Android.Resource.Id.Text2);
            itemView.Click += (sender, e) => clickListener(new RecyclerClickEventArgs {View = itemView, Position = AdapterPosition});
            itemView.LongClick += (sender, e) => longClickListener(new RecyclerClickEventArgs { View = itemView, Position = AdapterPosition });
        }

        public TextView TextView { get; set; }
        public TextView DetailTextView { get; set; }
    }

}

