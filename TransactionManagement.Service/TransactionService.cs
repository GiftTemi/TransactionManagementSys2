using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TransactionManagement.Data.Interface;
using TransactionManagement.Model;
using TransactionManagement.Model.ViewModel;

namespace TransactionManagement.Service
{
    public class TransactionService
    {
        private readonly IUnitOfWorks _unitOfWorks;

        public TransactionService(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }

        public async Task<ResponseModel> PostTransactions(CreateTransactionVM transactionVM)
        {
            var check = await _unitOfWorks.Account.GetById(transactionVM.AccountId);
            if(check == null)
            {
                return new ResponseModel
                {
                    Data = null,
                    Message = "Cannot Find Account Details",
                    StatusCode = HttpStatusCode.NotFound
                };
            }
            else
            {
                var transaction = new Transactions
                {
                    Id = Guid.NewGuid(),
                    AccountId = transactionVM.AccountId,
                    Amount = transactionVM.Amount,
                    FromAcct = transactionVM.FromAcct,
                    ToAcct = transactionVM.ToAcct,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Narration = transactionVM.Narration,
                    TransactionChannels = transactionVM.TransactionChannels,
                    TransactionType = transactionVM.TransactionType,
                    IsDeleted = false
                };

                _unitOfWorks.Transaction.Add(transaction);
                await _unitOfWorks.Complete();

                return new ResponseModel
                {
                    Data = transaction,
                    Message = "Transaction Posted Successfully",
                    StatusCode = HttpStatusCode.OK
                };
            }
        }
    }
}
