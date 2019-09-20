using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OFXProject
{
    internal class OFXBuilder
    {
        
        internal StringBuilder OFXFileBuilder = new StringBuilder();
        internal static string OFXFilePath { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\OFXFiles\TestOFX.ofx";
        private string _fI = "XXXX";
        private string _userID = "XXXXXX";
        TransactionCSVReader reader = new TransactionCSVReader();
        List<Transaction> readTransactions = new List<Transaction>();

        internal void WriteOFXFileHeader()
        {
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "OFXFiles"));

            readTransactions = reader.ReadTransactions(@"C:\Docs\Financial\transactions9-2019.csv").ToList();

            if (!File.Exists(OFXFilePath))
            {
                using (StreamWriter sw = File.CreateText(OFXFilePath))
                {

                    foreach(string initializationstring in OFXInitializationStrings)
                    {
                        sw.WriteLine(initializationstring);
                    }

                    sw.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "<DTSTART>" + readTransactions.First().DatePosted.ToString("yyyyMMddhhmmss"));
                    sw.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "<DTEND>" + readTransactions.Last().DatePosted.ToString("yyyyMMddhhmmss"));

                    foreach(Transaction transaction in readTransactions)
                    {
                        sw.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "<STMTTRN>");
                        sw.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "<TRNTYPE>" + transaction.TransactionType.ToUpper());
                        sw.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "</STMTTRN>");
                    }
                }
            }


            Console.WriteLine("Success!");      

            
        }


        internal string[] OFXInitializationStrings =
        {
            "OFXHEADER:100",
            "DATA:OFXSGML",
            "VERSION:102",
            "SECURITY:NONE",
            "ENCODING:USASCII",
            "CHARSET:1252",
            "COMPRESSION:NONE",
            "OLDFILEUID:NONE",
            "  ",
            "<OFX>",
            "\t" + "<SIGNONMSGSRSV1>",
            "\t" + "\t" + "<SONRS>",
            "\t" + "\t" + "\t" + "<STATUS>",
            "\t" + "\t" + "\t" + "\t" + "<CODE>0",
            "\t" + "\t" + "\t" + "\t" + "<SEVERITY>INFO",
            "\t" + "\t" + "\t" + "</STATUS>",
            "\t" + "\t" + "\t" + "<DTSERVER>" + DateTime.Now.ToString("yyyyMMddhhmmss"),
            "\t" + "\t" + "\t" + "<LANGUAGE>ENG",
            "\t" + "\t" + "\t" + "<DTPROFUP>20050531060000.000",
            "\t" + "\t" + "\t" + "<FI>",
            "\t" + "\t" + "\t" + "\t" + "<ORG>" + "AFCU",
            "\t" + "\t" + "\t" + "\t" + "<FID>1001",
            "\t" + "\t" + "\t" + "</FI>",
            "\t" + "\t" + "\t" + "<INTU.BID>54324",
            "\t" + "\t" + "\t" + "<INTU.USERID>" + "0000000",
            "\t" + "\t" + "</SONRS>",
            "\t" + "</SIGNONMSGSRSV1>",
            "\t" + "<BANKMSGSRSV1>",
            "\t" + "\t" + "<STMTTRNRS>",
            "\t" + "\t" + "\t" + "<TRNUID>0",
            "\t" + "\t" + "\t" + "<STATUS>",
            "\t" + "\t" + "\t" + "\t" + "<CODE>0",
            "\t" + "\t" + "\t" + "\t" + "<SEVERITY>INFO",
            "\t" + "\t" + "\t" + "</STATUS>",
            "\t" + "\t" + "\t" + "<STMTRS>",
            "\t" + "\t" + "\t" + "\t" + "<CURDEF>USD",
            "\t" + "\t" + "\t" + "\t" + "<BANKACCTFROM>",
            "\t" + "\t" + "\t" + "\t" + "\t" + "<BANKID>000000000",
            "\t" + "\t" + "\t" + "\t" + "\t" + "<ACCTID>000000~9",
            "\t" + "\t" + "\t" + "\t" + "\t" + "<ACCTTYPE>CHECKING",
            "\t" + "\t" + "\t" + "\t" + "</BANKACCTFROM>",
            "\t" + "\t" + "\t" + "\t" + "<BANKTRANLIST>"
        };
    }
}
