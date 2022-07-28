using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.Customers
{
    [Table("Customer")]
    public class Customer : FullAuditedEntity, IMustHaveTenant
    {
        public const int MaxNameLength = 32;
        public const int MaxEmailAddressLength = 255;
        public const int MaxAddressLength = 500;

        [Required]
        [MaxLength(MaxNameLength)]
        public virtual string Name { get; set; }

        [MaxLength(MaxEmailAddressLength)]
        public virtual string EmailAddress { get; set; }

        [MaxLength(MaxAddressLength)]
        public virtual string Address { get; set; }

        [Required]
        public virtual DateTime RegistrationDate { get; set; }

        public virtual ICollection<CustomerUsers> CustomerUsers { get; set; }

        public virtual int TenantId { get; set; }
    }
}
