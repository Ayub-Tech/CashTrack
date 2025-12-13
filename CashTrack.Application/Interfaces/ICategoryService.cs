using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashTrack.Application.Interfaces
{
    // Interface for category service
    public interface ICategoryService
    {
        // Will return all categories later
        void GetAll();

        // Will create a new category later
        void Create();
    }
}
