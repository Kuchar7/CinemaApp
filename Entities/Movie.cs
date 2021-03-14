using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int DurationMin { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public DateTime AddDateTime { get; set; }

        public virtual ICollection<Screening> Screenings { get; set; }
    }
}
