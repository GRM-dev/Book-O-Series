using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Model
{
    public class Episode
    {
        [Key]
        public int ID { get; set; }
        public int No { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ReleaseDate { get; set; }

        public virtual Season Season { get; set; }
    }
}
