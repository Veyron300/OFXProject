using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFXProject
{
    class Program
    {
        static void Main(string[] args)
        {
            OFXBuilder builder = new OFXBuilder();
            TransactionCSVReader reader = new TransactionCSVReader();
            List<Transaction> readTransactions = new List<Transaction>();

            readTransactions = reader.ReadTransactions(@"C:\Docs\Financial\transactions9-2019.csv").ToList();

            Console.WriteLine(readTransactions[0].DatePosted);
            Console.WriteLine(readTransactions[1].TransactionAmount);
            Console.WriteLine(readTransactions[2].TransactionAmount);

            builder.WriteOFXFileHeader();
            
        }
    }
}
