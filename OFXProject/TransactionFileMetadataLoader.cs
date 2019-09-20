using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFXProject
{
    public class TransactionFileMetadataLoader : ITransactionMetadataLoader
    {
        private string _csvFileFolderPath;
        public TransactionFileMetadata LoadedTransactionFileMetadata = new TransactionFileMetadata();

        public TransactionFileMetadataLoader(string csvFileFolderPath)
        {
            _csvFileFolderPath = csvFileFolderPath;
        }

        public TransactionFileMetadata LoadTransactionFileMetadata()
        {
            LoadedTransactionFileMetadata.FolderPath = _csvFileFolderPath;
            LoadedTransactionFileMetadata.FileType = "CSV";

            return LoadedTransactionFileMetadata;
        }
    }
}