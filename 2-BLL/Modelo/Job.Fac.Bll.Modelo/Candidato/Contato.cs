using System;
using Job.Fac.Bll.Modelo.Servicos.Contexto;
using Job.Fac.Bll.Modelo.Base.Argus.Modelo.Nucleo;

namespace Job.Fac.Bll.Modelo.Candidato.Contato
{
    public class Contato : ObjetoBase
    {
        private IServicoContexto servicoContexto;

        public Contato()
        {

        }

        public Contato(string nome, string telefone, string email, IServicoContexto servicoContexto)
        {
            this.servicoContexto = servicoContexto;
            Id = Guid.NewGuid();
            Email = email;
            Nome = nome;
            Telefone = telefone;
            DataCadastro = DateTime.Now;
            DataAlteracao = DateTime.Now;
            Excluido = false;
            Ativo = true;
            NomeInterno = ToString();
        }

        public Contato(IServicoContexto validadorContexto)
        {
            this.servicoContexto = validadorContexto;
            if (validadorContexto == null)
                throw new ArgumentNullException("Deve ser informado um contexto de validação para um contato.");
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                servicoContexto?.ValidacaoEmailServico?.Valida(value);

                email = value;
            }

        }

        public string Telefone
        {
            get
            {
                return telefone;
            }

            set
            {
                if (value == null)
                {
                    telefone = null;
                    return;
                }
                if (servicoContexto != null && servicoContexto.FormatacaoTextoServico != null)
                    telefone = servicoContexto.FormatacaoTextoServico.RemoverCaracteresEspeciais(value);
                else
                    telefone = value;
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                servicoContexto?.ValidacaoCompletoServico?.Valida(value);
                nome = value;
            }
        }

        private string nome;
        private string email;
        private string telefone;

        public override string ToString()
        {
            return $"{Nome} - {email}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Contato))
                return false;

            return (obj as Contato).Email.Equals(Email);
        }
    }
}