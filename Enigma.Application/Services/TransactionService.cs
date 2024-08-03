using Azure;
using Enigma.Application.DTOs;
using Enigma.Application.Interfaces;
using Enigma.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Application.Services
{
    public class TransactionService : ITransactionService
    {
        public List<TransactionResponse> GetClientTransactions(Guid clientId)
        {
            List<Transaction> transactions = _transactions.Where(w => w.ClientId == clientId).ToList();
            List<TransactionResponse> response = new List<TransactionResponse>();

            foreach (Transaction item in transactions)
            {
                TransactionResponse transactionResponse = new TransactionResponse();
                transactionResponse.Transaction_id = item.TransactionId;
                transactionResponse.Amount = item.Amount;
                transactionResponse.Date = item.Date.ToString("dd/MM/yyyy");
                transactionResponse.Description = item.Description;
                transactionResponse.Category = item.Category;
                response.Add(transactionResponse);
            }

            return response;
        }

        private readonly List<Transaction> _transactions = new List<Transaction>() 
        {
            new()
            {
                Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728965e"),
                TransactionId = "2913",
                Amount = 62.74m,
                Date = new DateTime(2024, 5, 30),
                Description = "Grocery shopping",
                Category = "Food & Dinning",
                ClientId = new Guid("0f8fad5b-d9cb-469f-a165-70867728940e")
            },
            new()
            {
                Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728966e"),
                TransactionId = "3382",
                Amount = 18.84m,
                Date = new DateTime(2024, 5, 29),
                Description = "Grocery shopping",
                Category = "Food & Dinning",
                ClientId = new Guid("0f8fad5b-d9cb-469f-a165-70867728940e")
            },
            new()
            {
                Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728966e"),
                TransactionId = "1143",
                Amount = 40.11m,
                Date = new DateTime(2024, 5, 30),
                Description = "Gas station purchase",
                Category = "Utilities",
                ClientId = new Guid("0f8fad5b-d9cb-469f-a165-70867728940e")
            }
        };  
    }
}
