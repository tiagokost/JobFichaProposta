using System;

namespace Job.Fac.Bll.Modelo.Excecoes
{
    public class ModeloInvalidoExcecao : Exception
    {
        public ModeloInvalidoExcecao(string msg)
            :base(msg)
        {

        }

        public ModeloInvalidoExcecao(string msg,Exception excecaoInterna)
            : base(msg, excecaoInterna)
        {

        }
    }
}
