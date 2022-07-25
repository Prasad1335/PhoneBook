using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyTraining1121AngularDemo.Authorization.Users.Dto;
using MyTraining1121AngularDemo.Customers.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.Customers
{
    public interface ICustomerUserAppService : IApplicationService
    {
        ListResultDto<UserListDto> GetCustomerUser();
        ListResultDto<CustomerUserListDto> GetCustomerUserList();
        Task CreateCustomerUser(CreateCustomerUserInput input);
    }
}