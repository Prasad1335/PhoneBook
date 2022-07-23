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

        public CustomerAppService(IRepository<Customer> CustomerRepository)
        {
            _CustomerRepository = CustomerRepository;
        }

        public ListResultDto<CustomerListDto> GetPeople(GetPeopleInput input)
        {
            var Customers = _CustomerRepository
                .GetAll()
                //  .Include(p => p.Phones)
                .WhereIf(
                    !input.Filter.IsNullOrEmpty(),
                    p => p.Name.Contains(input.Filter) ||
                            p.EmailAddress.Contains(input.Filter) ||
                            p.Address.Contains(input.Filter) 
                           // p.RegistrationDate.Contains(input.Filter)
                )
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Address)
                .ToList();

            return new ListResultDto<CustomerListDto>(ObjectMapper.Map<List<CustomerListDto>>(Customers));
        }


        [AbpAuthorize(AppPermissions.Pages_Tenant_Customer_CreateCustomer)]
        public async Task CreateCustomer(CreateCustomerInput input)
        {
            var cust = ObjectMapper.Map<Customer>(input);
            await _CustomerRepository.InsertAsync(cust);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_Customer_DeleteCustomer)]
        public async Task DeleteCustomer(EntityDto input)
        {
            await _CustomerRepository.DeleteAsync(input.Id);
        }























        //[AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook_EditPerson)]
        //public async Task<PhoneInPersonListDto> AddPhone(AddPhoneInput input)
        //{
        //    var person = _personRepository.Get(input.PersonId);
        //    await _personRepository.EnsureCollectionLoadedAsync(person, p => p.Phones);

        //    var phone = ObjectMapper.Map<Phone>(input);
        //    person.Phones.Add(phone);

        //    //Get auto increment Id of the new Phone by saving to database
        //    await CurrentUnitOfWork.SaveChangesAsync();

        //    return ObjectMapper.Map<PhoneInPersonListDto>(phone);
        //}

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
