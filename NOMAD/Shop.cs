using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOMAD
{
    public class Shop
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int JournalNumber { get; set; }
        public string JournalName { get; set; }
        public int JournalMoney { get; set; }
    }
}
