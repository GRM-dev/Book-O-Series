using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Model
{
    public class Genre
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Series> Series { get; set; }
    }
}
