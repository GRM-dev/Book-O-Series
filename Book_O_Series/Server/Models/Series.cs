using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Series
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Storyline { get; set; }
        public string ImagePath { get; set; }
        public float Rate { get; set; }
        public virtual ICollection<Season> Seasons { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }

        internal string ToJson()
        {
            throw new NotImplementedException();
        }
    }
}
