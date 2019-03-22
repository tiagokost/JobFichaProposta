using Job.Fac.Bll.Modelo.Excecoes;
using System;

namespace Job.Fac.Bll.Modelo.Servicos.Candidato
{
    public class ValidadorNomeServico : IValidadorNomeServico
    {
        private bool valido;

        public bool Valido
        {
            get
            {
                return valido;
            }
        }

        public IValidadorServico<string> Valida(string o)
        {
            if (o == null)
                throw new ModeloInvalidoExcecao("O nome não pode ser nulo.");

            var oA = o.Split(' ');

            if (oA.Length < 2)
                throw new ModeloInvalidoExcecao("Informe um nome e sobrenome.");
            this.valido = true;
            return this;
        }

    }
}
