using Enigma.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Application.Interfaces
{
    public interface ITransactionService
    {
        List<TransactionResponse> GetClientTransactions(Guid clientId);
    }
}
