using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.Customers.Dto
{
    public class EditCustomerInput
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string Address { get; set; }

        public virtual DateTime RegistrationDate { get; set; }
    }


    public class GetCustomerForEditOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string Address { get; set; }

        public virtual DateTime RegistrationDate { get; set; }


    }
    public class GetCustomerForEditInput
    {
        public int Id { get; set; }
    }
}

