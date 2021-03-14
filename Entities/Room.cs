using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Rooms")]
    public class Room
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public virtual ICollection<Screening> Screenings { get; set; }
        public virtual ICollection<ReservedSeat> ReservedSeats { get; set; }
    }
}
