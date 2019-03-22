using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Fac.Bll.Excecoes
{
    public class BllExcecao : Exception
    {
        public BllExcecao(string msg):base(msg)
        {

        }
        public BllExcecao(string msg,Exception excecaoInterna)
            :base(msg,excecaoInterna)
        {

        }

        public BllExcecao(Exception excecaoInterna)
            :base("Uma exceção foi lançada na camada de domínio.",excecaoInterna)
        {

        }
    }
}
