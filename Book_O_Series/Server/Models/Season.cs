using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Season
    {
        [Key]
        public int Id { get; set; }
        public virtual Series Series { get; set; }
        public virtual ICollection<Episode> Episodes { get; set; }
    }
}
