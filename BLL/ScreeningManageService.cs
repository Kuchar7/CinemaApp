using CinemaApp.DTO;
using DAL;
using Entities;
using IBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{

    public class ScreeningManageService : IScreeningManageService
    {
        readonly DatabaseContext dbContext;

        public ScreeningManageService(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int AddScreening(AddScreeningDTO addScreeningDTO)
        {


            Screening newScreening = new Screening
            {
                MovieId = addScreeningDTO.MovieId,
                RoomId = addScreeningDTO.RoomId,
                BasicPrice = addScreeningDTO.Price,
                Start = addScreeningDTO.Start
            };
            dbContext.Screenings.Add(newScreening);
            return dbContext.SaveChanges();
        }
    }
}

//w tej klasie mam metody do zapisywania w bazie danych, edycji, usuwania