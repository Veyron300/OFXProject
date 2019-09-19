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

            builder.WriteOFXFileHeader();
            
        }
    }
}
