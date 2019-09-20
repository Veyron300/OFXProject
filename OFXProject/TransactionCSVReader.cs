using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFXProject
{
    public class TransactionCSVReader
    {
        private static IList<Transaction> _csvTransactions;
        private static ITransactionMetadataLoader _csvTransactionMetaloader;

        public IList<Transaction> ReadTransactions(string folderPath)
        {
            _csvTransactionMetaloader = new TransactionFileMetadataLoader(folderPath);
            TransactionCSVParser parser = new TransactionCSVParser(_csvTransactionMetaloader);
            _csvTransactions = parser.ParseTransactions().ToList();
            return _csvTransactions;
        }
    }
}
