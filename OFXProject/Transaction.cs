using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFXProject
{
    public class Transaction
    {
        public DateTime DatePosted { get; set; }
        public string TransactionType { get; set; }
        public string TransactionAmount { get; set; }
        public string Description { get; set; }
        public string OriginalDescription { get; set; }
        public bool Pending { get; set; }
    }
}
