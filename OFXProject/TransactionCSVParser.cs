using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OFXProject
{
    public class TransactionCSVParser : ITransactionParser<Transaction>
    {
        ITransactionMetadataLoader _sourcemetadataloader;

        public TransactionCSVParser(ITransactionMetadataLoader sourcemetadataloader)
        {
            _sourcemetadataloader = sourcemetadataloader;
        }

        public IEnumerable<Transaction> ParseTransactions()
        {
            var transactionquery =
                from line in File.ReadAllLines(_sourcemetadataloader.LoadTransactionFileMetadata().FolderPath).Skip(1)
                let data = line.Split(',')
                where data[0].Length > 0
                select new Transaction()
                {
                    DatePosted = DateTime.Parse(data[0]),
                    Description = string.Copy(data[1]),
                    OriginalDescription = string.Copy(data[2]),
                    TransactionAmount = double.Parse(data[3]),
                    TransactionType = string.Copy(data[4])

                };

            return transactionquery.ToList();
        }
    }
}
