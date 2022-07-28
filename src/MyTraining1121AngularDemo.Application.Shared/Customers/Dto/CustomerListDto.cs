using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.Customers.Dto
{

    public class CustomerListDto : FullAuditedEntityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string Address { get; set; }

        public virtual DateTime RegistrationDate { get; set; }

        public Collection<CustomerUserListDto> Customers { get; set; }
    }
}
