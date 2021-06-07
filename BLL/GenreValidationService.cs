using DAL;
using IBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GenreValidationService : IGenreValidationService
    {
        readonly DatabaseContext dbContext;

        public GenreValidationService(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool IsNameExist(string genreName)
        {
            bool isNameExist = dbContext.Genres.Any(x => x.Name == genreName);
            return isNameExist;
        }
    }
}
