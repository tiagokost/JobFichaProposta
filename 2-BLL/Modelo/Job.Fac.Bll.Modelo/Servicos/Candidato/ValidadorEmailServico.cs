using Job.Fac.Bll.Modelo.Excecoes;
using System;
using System.Text.RegularExpressions;

namespace Job.Fac.Bll.Modelo.Servicos.Candidato
{
    public class ValidadorEmailServico : IValidadorEmailServico
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
            valido = false;

            if (string.IsNullOrEmpty(o) || string.IsNullOrWhiteSpace(o))
                throw new ArgumentNullException("Um email nulo não é permitido.");

            if (!o.Contains("@"))
                throw new ModeloInvalidoExcecao("O E-mail deve conter um arroba.");

            if (o.StartsWith("@"))
                throw new ModeloInvalidoExcecao($"O email não pode começar com arroba.\n{o}");

            if (o.EndsWith("@"))
                throw new ModeloInvalidoExcecao($"O email não pode terminar com arroba.\n{o}");

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            Match match = regex.Match(o);

            if (!match.Success)
                throw new ModeloInvalidoExcecao($"O email {o} não é válido.");

      
            this.valido = true;
            return this;
        }

    }
}
