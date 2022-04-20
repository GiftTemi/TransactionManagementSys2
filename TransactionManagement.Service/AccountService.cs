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
    public class AccountService
    {
        private readonly IUnitOfWorks _unitOfworks;

        public AccountService(IUnitOfWorks unitOfworks)
        {
            _unitOfworks = unitOfworks;
        }

        public async Task<ResponseModel> CreateAccount(CreateAccountVM accountVM)
        {
            if(accountVM.CustomerId == Guid.Empty)
            {
                throw new ArgumentNullException("Customer Id Cannot Be Empty");
            }

            if(accountVM.AccountType != Model.Enums.AccountType.CURRENT || accountVM.AccountType != Model.Enums.AccountType.SAVINGS)
            {
                throw new ArgumentException("Please Enter The Appropriate Account Type");
            }

            var check = await _unitOfworks.Customer.GetById(accountVM.CustomerId);
            if(check == null)
            {
                return new ResponseModel
                {
                    Data = null,
                    Message = "Cannot Find Customer Details",
                    StatusCode = HttpStatusCode.NotFound
                };
            }
            else
            {
                var account = new Account
                {
                    Id = Guid.NewGuid(),
                    AccountType = accountVM.AccountType,
                    BranchCode = accountVM.BranchCode,
                    CreatedDate = DateTime.Now,
                    CustomerId = accountVM.CustomerId,
                    CustomerNumber = accountVM.CustomerNumber,
                    LegerCode = accountVM.LegerCode,
                    Nuban = accountVM.Nuban,
                    ModifiedDate = DateTime.Now,
                    IsDeleted = false
                };
                _unitOfworks.Account.Add(account);
                await _unitOfworks.Complete();

                return new ResponseModel
                {
                    Data = account,
                    Message = "Account Created Successfully",
                    StatusCode = HttpStatusCode.OK
                };
            }
        }
    }
}
