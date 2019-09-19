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
         
        internal void WriteOFXFileHeader()
        {
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "OFXFiles"));

            if (!File.Exists(OFXFilePath))
            {
                using (StreamWriter sw = File.CreateText(OFXFilePath))
                {
                    sw.WriteLine("OFXHEADER:100");
                    sw.WriteLine("DATA:OFXSGML");
                    sw.WriteLine("VERSION:102");
                    sw.WriteLine("SECURITY:NONE");
                    sw.WriteLine("ENCODING:USASCII");
                    sw.WriteLine("CHARSET:1252");
                    sw.WriteLine("COMPRESSION:NONE");
                    sw.WriteLine("OLDFILEUID:NONE");
                    sw.WriteLine("NEWFILEUID:NONE");
                    sw.WriteLine("  ");
                    sw.WriteLine("<OFX>");
                    sw.WriteLine("\t" + "<SIGNONMSGSRSV1>");
                    sw.WriteLine("\t" + "\t" + "<SONRS>");
                    sw.WriteLine("\t" + "\t" + "\t" + "<STATUS>");
                    sw.WriteLine("\t" + "\t" + "\t" + "\t" + "<CODE>0");
                    sw.WriteLine("\t" + "\t" + "\t" + "\t" + "<SEVERITY>INFO");
                    sw.WriteLine("\t" + "\t" + "\t" + "</STATUS>");
                    sw.WriteLine("\t" + "\t" + "\t" + "<DTSERVER>" + DateTime.Now.ToString("yyyyMMddhh"));
                    sw.WriteLine("\t" + "\t" + "\t" + "<LANGUAGE>ENG");
                    sw.WriteLine("\t" + "\t" + "\t" + "<DTPROFUP>20050531060000.000");
                    sw.WriteLine("\t" + "\t" + "\t" + "<FI>");
                    sw.WriteLine("\t" + "\t" + "\t" + "\t" + "<ORG>" + _fI);
                    sw.WriteLine("\t" + "\t" + "\t" + "\t" + "<FID>1001");
                    sw.WriteLine("\t" + "\t" + "\t" + "</FI>");
                    sw.WriteLine("\t" + "\t" + "\t" + "<INTU.BID>54324");
                    sw.WriteLine("\t" + "\t" + "\t" + "<INTU.USERID>" + _userID);
                    sw.WriteLine("\t" + "\t" + "</SONRS>");
                    sw.WriteLine("\t" + "</SIGNONMSGSRSV1>");
                    sw.WriteLine("\t" + "<BANKMSGSRSV1>");
                    sw.WriteLine("\t" + "\t" + "<STMTTRNRS>");
                    sw.WriteLine("\t" + "\t" + "\t" + "<TRNUID>0");
                    sw.WriteLine("\t" + "\t" + "\t" + "<STATUS>");

                }
            }


            Console.WriteLine("Success!");
            
         

            
        }

        internal void WriteTextToOFXFile()
        {

        }
    }
}
