namespace Book_O_Series.Models
{
    public class Item : BaseDataObject
    {
        private string _description = string.Empty;

        /// <summary>
        /// Private backing field to hold the text
        /// </summary>
        string _text = string.Empty;

        public Item() : base()
        {
        }

        /// <summary>
        /// Public property to set and get the text of the item
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

    }
}
