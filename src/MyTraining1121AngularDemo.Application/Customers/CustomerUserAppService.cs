using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
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
    public class CustomerUserAppService : MyTraining1121AngularDemoAppServiceBase, ICustomerUserAppService
    {
        private readonly IRepository<User, long> _UserRepository;
        private readonly IRepository<CustomerUsers> _CustomerUserRepository;

        public CustomerUserAppService(IRepository<User, long> userRepository, IRepository<CustomerUsers> customerUserRepository)
        {
            _UserRepository = userRepository;
            _CustomerUserRepository = customerUserRepository;
        }

        public ListResultDto<UserListDto> GetCustomerUser()
        {
            var userList = _UserRepository.GetAll().ToList();

            return new ListResultDto<UserListDto>(ObjectMapper.Map<List<UserListDto>>(userList));
        }


        public ListResultDto<CustomerUserListDto> GetCustomerUserList()
        {
            var customerUserList = _CustomerUserRepository.GetAll().ToList();

            return new ListResultDto<CustomerUserListDto>(ObjectMapper.Map<List<CustomerUserListDto>>(customerUserList));
        }


        public async Task CreateCustomerUser(CreateCustomerUserInput input)
        {
            var addCustomerUser = ObjectMapper.Map<CustomerUsers>(input);
            await _CustomerUserRepository.InsertAsync(addCustomerUser);
        }
    }
}
