using Abp.Application.Services.Dto;
using MyTraining1121AngularDemo.Authorization.Users.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyTraining1121AngularDemo.Customers.Dto
{
    public class CustomerUserListDto
    {


        public int CustomerId { get; set; }

        public long UserId { get; set; }

        //public string Name { get; set; }

        //public string Surname { get; set; }

        //public string EmailAddress { get; set; }


    }

    //public class USersListDto : EntityDto<long>
    //{
    //    public string Name { get; set; }

    //    public string Surname { get; set; }
       
    //    public string EmailAddress { get; set; }
    //}
}
