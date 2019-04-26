using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOMAD
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; }
        public int DateSubscribe { get; set; }
        public int MoneySubcription { get; set;}
        public int IfSubscribe { get; set;}
        public DateTime DeadLine { get; set; }


        public Guid ShopId { get; set; }

    }
}
