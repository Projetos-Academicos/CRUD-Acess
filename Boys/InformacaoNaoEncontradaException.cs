using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boys
{
    class InformacaoNaoEncontradaException : Exception
    {
        public InformacaoNaoEncontradaException()
        {

        }
        public InformacaoNaoEncontradaException(string msg) : base(msg)
        {

        }
    }
}
