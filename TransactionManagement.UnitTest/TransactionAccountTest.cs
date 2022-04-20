using System;
using System.Threading.Tasks;
using TransactionManagement.Data.Interface;
using TransactionManagement.Data.Repository;
using TransactionManagement.Service;
using Xunit;

namespace TransactionManagement.UnitTest
{
    public class TransactionAccountTest
    {
        [Fact]
        public async Task Test_Invalid_CustomerId()
        {
            IUnitOfWorks unitOfWork = new UnitOfWorks();
            var accountService = new AccountService(unitOfWork);

            await Assert.ThrowsAsync<ArgumentNullException>(() => accountService.CreateAccount(new Model.ViewModel.CreateAccountVM()));
        }

        [Fact]
        public async Task Test_Invalid_AccountType()
        {
            IUnitOfWorks unitOfWork = new UnitOfWorks();
            var accountService = new AccountService(unitOfWork);

            await Assert.ThrowsAsync<ArgumentException>(() => accountService.CreateAccount(new Model.ViewModel.CreateAccountVM { CustomerId = Guid.NewGuid()}));
        }
    }
}
