using System;

namespace Job.Fac.Bll.Excecoes
{
    public class ObjetoNaoRegistradoExcecao : BllExcecao
    {
        public ObjetoNaoRegistradoExcecao(string msg):base(msg)
        {

        }
        public ObjetoNaoRegistradoExcecao(string msg, Exception excecaoInterna)
            :base(msg,excecaoInterna)
        {

        }

        public ObjetoNaoRegistradoExcecao(Exception excecaoInterna)
            :base("Não foi possível enviar o e-mail.\nConsulte as exceções internas.",excecaoInterna)
        {

        }
        public ObjetoNaoRegistradoExcecao()
        : base("Não foi possível enviar o e-mail.")
        {

        }
    }
}
