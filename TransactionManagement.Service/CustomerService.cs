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
    public class CustomerService
    {
        private readonly IUnitOfWorks _unitOfWork;

        public CustomerService(IUnitOfWorks unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseModel> CreateCustomer(CreateCustomerVM customerVM)
        {
            try
            {
                var newCustomer = new Customer();
                var customer = await _unitOfWork.Customer.GetCustomerByBVN(customerVM.BVN);
                if (customer == null)
                {
                    newCustomer.Id = Guid.NewGuid();
                    newCustomer.Address = customerVM.Address;
                    newCustomer.LGA = customerVM.LGA;
                    newCustomer.BVN = customerVM.BVN;
                    newCustomer.CreatedDate = DateTime.Now;
                    newCustomer.DOB = customerVM.DOB;
                    newCustomer.Email = customerVM.Email;
                    newCustomer.FirstName = customerVM.FirstName;
                    newCustomer.Gender = customerVM.Gender;
                    newCustomer.LastName = customerVM.LastName;
                    newCustomer.MiddleName = customerVM.MiddleName;
                    newCustomer.PhoneNumber = customerVM.PhoneNumber;
                    newCustomer.MotherMaidenName = customerVM.MotherMaidenName;
                    newCustomer.ModifiedDate = DateTime.Now;
                    newCustomer.State = customerVM.State;
                    newCustomer.IsDeleted = false;

                    _unitOfWork.Customer.Add(newCustomer);
                    await _unitOfWork.Complete();

                    return new ResponseModel
                    {
                        Data = newCustomer,
                        Message = "Customer Created Successfully",
                        StatusCode = HttpStatusCode.OK
                    };
                }
                else
                {
                    return new ResponseModel
                    {
                        Data = customer,
                        Message = "Customer Already Exist",
                        StatusCode = HttpStatusCode.BadRequest
                    };
                }
            }
            catch (Exception ex)
            {

                throw ;
            }
           
           
        }
    }
}
