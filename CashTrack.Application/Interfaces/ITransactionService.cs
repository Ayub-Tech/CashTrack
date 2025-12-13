using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashTrack.Application.Interfaces
{
    // Interface for transaction service
    public interface ITransactionService
    {
        // Will return all transactions later
        void GetAll();

        // Will create a new transaction later
        void Create();
    }
}
