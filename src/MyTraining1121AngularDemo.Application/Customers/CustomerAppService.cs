using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyTraining1121AngularDemo.Authorization;
using MyTraining1121AngularDemo.Customers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.Customers
{
    [AbpAuthorize(AppPermissions.Pages_Tenant_Customer)]
    public class CustomerAppService : MyTraining1121AngularDemoAppServiceBase, ICustomerAppService
    {
        private readonly IRepository<Customer> _CustomerRepository;
        private readonly IRepository<CustomerUsers> _CustomerUsersRepository;

        public CustomerAppService(IRepository<Customer> CustomerRepository, IRepository<CustomerUsers> customerUsersRepository)
        {
            _CustomerRepository = CustomerRepository;
            _CustomerUsersRepository = customerUsersRepository;
        }

        public ListResultDto<CustomerListDto> GetPeople(GetPeopleInput input)
        {
            var Customers = _CustomerRepository.GetAll()
                .WhereIf(!input.Filter.IsNullOrEmpty(),
                         p => p.Name.Contains(input.Filter) ||
                         p.EmailAddress.Contains(input.Filter) ||
                         p.Address.Contains(input.Filter))
                .ToList();

            return new ListResultDto<CustomerListDto>(ObjectMapper.Map<List<CustomerListDto>>(Customers));
        }


        //public ListResultDto<CustomerUserListDto> CustomerUserGetById(int id)
        //{
        //    var CustomerUser = _CustomerUsersRepository.GetAll()
        //       .Where(u => u.UserId == id).ToList();

        //    return new ListResultDto<CustomerUserListDto>(ObjectMapper.Map<List<CustomerUserListDto>>(CustomerUser));
        //}


        [AbpAuthorize(AppPermissions.Pages_Tenant_Customer_CreateCustomer)]
        public async Task CreateCustomer(CreateCustomerInput input)
        {

            var customer = ObjectMapper.Map<Customer>(input);
            await _CustomerRepository.InsertAndGetIdAsync(customer);

            var Customers = _CustomerRepository.GetAll().ToList();

            var cust = Customers.Last();

            var customerID = cust.Id;

          
            //for (int i = 0; i < users; i++)
            //{
            //    var user = input.UserId.Add(i);
            //    var customerUser = new CustomerUsers { CustomerId = customerID, UserId = user };
            //    await _CustomerUsersRepository.InsertAsync(customerUser);

            //}

            foreach(long i in input.UserId)
            {
                
                var customerUser = new CustomerUsers { CustomerId = customerID, UserId = i };
                await _CustomerUsersRepository.InsertAsync(customerUser);
            }

        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_Customer_DeleteCustomer)]
        public async Task DeleteCustomer(EntityDto input)
        {
            await _CustomerRepository.DeleteAsync(input.Id);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_Customer_EditCustomer)]
        public async Task<GetCustomerForEditOutput> GetCustomerForEdit(GetCustomerForEditInput input)
        {
            var customer = await _CustomerRepository.GetAsync(input.Id);
            return ObjectMapper.Map<GetCustomerForEditOutput>(customer);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_Customer_EditCustomer)]
        public async Task EditCustomer(EditCustomerInput input)
        {
            var customer = await _CustomerRepository.GetAsync(input.Id);
            customer.Name = input.Name;
            customer.EmailAddress = input.EmailAddress;
            customer.Address = input.Address;
            customer.RegistrationDate = input.RegistrationDate;
            await _CustomerRepository.UpdateAsync(customer);
        }
    }
}
