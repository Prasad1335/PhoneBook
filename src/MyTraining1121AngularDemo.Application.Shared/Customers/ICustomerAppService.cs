
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyTraining1121AngularDemo.Customers.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.Customers
{

    public interface ICustomerAppService : IApplicationService
    {
        ListResultDto<CustomerListDto> GetPeople(GetPeopleInput input);
        Task CreateCustomer(CreateCustomerInput input);
        Task DeleteCustomer(EntityDto input);
        ////Task DeletePhone(EntityDto<long> input);
        //Task<CustomerUserInCustomerListDto> AddPhone(AddCustomerUserInput input);
        Task<GetCustomerForEditOutput> GetCustomerForEdit(GetCustomerForEditInput input);
        Task EditCustomer(EditCustomerInput input);


    }
}
