using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL
{
    public interface IGenreValidationService
    {
        bool IsNameExist(string genreName);
    }
}
