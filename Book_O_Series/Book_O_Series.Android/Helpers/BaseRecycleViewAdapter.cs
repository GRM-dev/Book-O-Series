using System;
using Android.Support.V7.Widget;
using Android.Views;

namespace Book_O_Series.Droid.Helpers
{
    public class BaseRecycleViewAdapter : RecyclerView.Adapter
    {
        public event EventHandler<RecyclerClickEventArgs> ItemClick;
        public event EventHandler<RecyclerClickEventArgs> ItemLongClick;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            throw new NotImplementedException();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            throw new NotImplementedException();
        }

        protected void OnClick(RecyclerClickEventArgs args) => ItemClick?.Invoke(this, args);
        protected void OnLongClick(RecyclerClickEventArgs args) => ItemLongClick?.Invoke(this, args);

        public override int ItemCount
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}

