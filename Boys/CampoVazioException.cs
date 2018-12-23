using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boys
{
    public class CampoVazioException : Exception
    {
        public CampoVazioException()
        {
            
        }
        public CampoVazioException(string msg) : base(msg)
        {

        }


    }
}
