using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL
{
    public interface IReservationValidationService
    {
        bool IsAvailable(IEnumerable<int> seats, int screeningId);
    }
}
