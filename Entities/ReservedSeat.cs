using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("ReserveredSeats")]
    public class ReservedSeat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Number { get; set; }


        [ForeignKey("Reservation")]
        public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }
        [ForeignKey("Screening")]
        public int ScreeningId { get; set; }
        public virtual Screening Screening { get; set; }
        [ForeignKey("Room")]
        public int? RoomId { get; set; }
        public virtual Room Room { get; set; }

    }
}
