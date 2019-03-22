using System;

namespace Job.Fac.Bll.Excecoes
{
    public class EnvioDeEmailExcecao : BllExcecao
    {
        public EnvioDeEmailExcecao(string msg):base(msg)
        {

        }
        public EnvioDeEmailExcecao(string msg, Exception excecaoInterna)
            :base(msg,excecaoInterna)
        {

        }

        public EnvioDeEmailExcecao(Exception excecaoInterna)
            :base("Não foi possível enviar o e-mail.\nConsulte as exceções internas.",excecaoInterna)
        {

        }
        public EnvioDeEmailExcecao()
        : base("Não foi possível enviar o e-mail.")
        {

        }
    }
}
