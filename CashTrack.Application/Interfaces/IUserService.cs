using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashTrack.Application.Interfaces
{
    // Interface for user service
    public interface IUserService
    {
        // Will return all users later
        void GetAll();

        // Will create a new user later
        void Create();
    }
}