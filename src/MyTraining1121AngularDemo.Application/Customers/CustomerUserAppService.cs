using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using MyTraining1121AngularDemo.Authorization;
using MyTraining1121AngularDemo.Authorization.Users;
using MyTraining1121AngularDemo.Authorization.Users.Dto;
using MyTraining1121AngularDemo.Customers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.Customers
{
    [AbpAuthorize(AppPermissions.Pages_Tenant_Customer)]
    public class CustomerUserAppService : MyTraining1121AngularDemoAppServiceBase, ICustomerUserAppService
    {
        private readonly IRepository<CustomerUsers> _CustomerUserRepository;
        private readonly IRepository<User, long> _userRepository;

        public CustomerUserAppService(IRepository<CustomerUsers> customerUserRepository, IRepository<User, long> userRepository)
        {
            _CustomerUserRepository = customerUserRepository;
            _userRepository = userRepository;
        }

        public ListResultDto<UserListSecondDto> GetCustomerUserList(long CustomerId)
        {
            var customerUserList = _CustomerUserRepository
                .GetAll()
                   .Include(c => c.User)
                .Where(w => w.CustomerId == CustomerId)
                  .Select(u => u.User)
                .ToList();
            return new ListResultDto<UserListSecondDto>(ObjectMapper.Map<List<UserListSecondDto>>(customerUserList));
        }


        public async Task CreateCustomerUser(CreateCustomerUserInput input)
        {
            var addCustomerUser = ObjectMapper.Map<CustomerUsers>(input);
            await _CustomerUserRepository.InsertAsync(addCustomerUser);
        }
    }
}




