using Book_O_Series.Models;

namespace Book_O_Series.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        private int _quantity = 1;

        public ItemDetailViewModel(Item item = null)
        {
            if (item == null) return;
            Title = item.Text;
            Item = item;
        }

        public Item Item { get; set; }

        public int Quantity
        {
            get { return _quantity; }
            set { SetProperty(ref _quantity, value); }
        }
    }
}