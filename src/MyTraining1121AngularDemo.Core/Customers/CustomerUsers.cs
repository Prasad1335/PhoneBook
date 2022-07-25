using Abp.Domain.Entities.Auditing;
using MyTraining1121AngularDemo.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.Customers
{
    [Table("CustomerUsers")]
    public class CustomerUsers : FullAuditedEntity
    {
       
        public virtual int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public virtual long UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual decimal? totalBillingAmount { get; set; }

    }
}

