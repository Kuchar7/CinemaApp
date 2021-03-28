using CinemaApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL
{
    public interface IScreeningDisplayService
    {
        IEnumerable<ScreeningDisplayDTO> GetScreeningByParametr(string starteDateTime, string endDateTime);
        IEnumerable<ScreeningDisplayDTO> GetScreeningByParametr(string starteDateTime, string endDateTime, string movieTitle);
    }
}
