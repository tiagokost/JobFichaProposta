namespace Job.Fac.Bll.Modelo.Base
{
    using System;

    namespace Argus.Modelo.Nucleo
    {
        public class ObjetoBase
        {

            public ObjetoBase()
            {

            }
            public ObjetoBase(Guid id, DateTime dataAlteracao, bool excluido, bool ativo, string nomeInterno)
            {
                DataAlteracao = dataAlteracao;
                Excluido = excluido;
                Ativo = ativo;
                Id = id;
            }

            public ObjetoBase(bool excluido, bool ativo, string nomeInterno)
            {
                Id = Guid.NewGuid();
                DataAlteracao = DateTime.Now;
                DataCadastro = DateTime.Now;
                Excluido = excluido;
                Ativo = ativo;
            }

            public virtual Guid Id { get; set; }
            public virtual DateTime DataCadastro { get; set; }
            public virtual DateTime DataAlteracao { get; set; }
            public virtual bool Excluido { get; set; }
            public virtual bool Ativo { get; set; }
            public virtual string NomeInterno { get; set; }

            public bool Equals(Guid id)
            {
                return Id.Equals(id);
            }

            public virtual bool Valida()
            {
                return true;
            }

            public void Excluir()
            {
                Excluido = true;
            }

            public void Restaurar()
            {
                Excluido = false;
            }

            public void Desativar()
            {
                this.Ativo = false;
            }

            public void Ativar()
            {
                this.Ativo = true;
            }
        }
    }

}
