using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Model
{
    public class Season
    {
        [Key]
        public int ID { get; set; }

        public virtual Series Series { get; set; }
        public virtual ICollection<Episode> Episodes { get; set; }
    }
}
