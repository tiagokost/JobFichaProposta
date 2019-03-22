using Job.Fac.Ui.Nucleo.Enum;
using System;
using System.Collections.Generic;

namespace Job.Fac.Ui.Nucleo
{
    public static class Mensagens
    {
        public static Mensagem[] MontarMensagemComExcecoes(Exception ex)
        {
            var a = new List<Mensagem>();
            do
            {
                a.Add(new Mensagem("", ex.Message,TipoDeMensagens.Erro));
                ex = ex.InnerException;
            } while (ex != null);
            return a.ToArray();
        }

        public static Mensagem[] Sucesso(string mensagem)
        {
            var a = new List<Mensagem>();
            a.Add(new Mensagem("",mensagem,TipoDeMensagens.Sucesso));
            return a.ToArray();
        }
    }
}
