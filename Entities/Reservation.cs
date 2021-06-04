using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Reservations")]
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal Price { get; set; }


        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("ReservationStatus")]
        public int StatusId { get; set; }
        public virtual ReservationStatus ReservationStatus { get; set; }
        [ForeignKey("Screening")]
        public int ScreeningId { get; set; }
        public virtual Screening Screening { get; set; }
        public virtual ICollection<ReservedSeat> ReservedSeats { get; set; }
    }
}
