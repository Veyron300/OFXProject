using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFXProject
{
    public interface ITransactionMetadataLoader
    {
        TransactionFileMetadata LoadTransactionFileMetadata();
    }
}
