using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOMAD
{
    public class Company
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ShopId { get; set; }
        public Guid UserId { get; set; }
        public int ReportSubscibe {get;set;}
        public int ReportMoney {get;set;}
        public double EndSubscribe { get; set; }
    }
}
