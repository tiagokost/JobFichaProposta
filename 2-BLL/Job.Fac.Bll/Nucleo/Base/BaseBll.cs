using Job.Fac.Bll.Excecoes;
using Job.Fac.Bll.Modelo.Base.Argus.Modelo.Nucleo;
using Job.Fac.Bll.Modelo.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Job.Fac.Bll.Nucleo.Base
{
    public abstract class BaseBll<T> : IBaseBll<T> where T : ObjetoBase
    {
        private BaseBll()
        {

        }

        public BaseBll(IBaseDao<T> dao)
        {
            this.dao = dao;
        }

        protected delegate T AntesDeModificarManipuladorDeEvento(T o);

        protected AntesDeModificarManipuladorDeEvento AntesDeModificar;

        protected delegate T AntesDeRegistrarManipuladorDeEvento(T o);

        protected AntesDeRegistrarManipuladorDeEvento AntesDeRegistrar;

        protected delegate T DepoisDeRegistrarManipuladorDeEvento(T o);

        protected DepoisDeRegistrarManipuladorDeEvento DepoisDeRegistrar;

        private readonly IBaseDao<T> dao;

        public virtual IEnumerable<T> ObterTodos()
        {
            return dao.Selecionar().Where(x => !x.Excluido);
        }

        public virtual IEnumerable<T> ObterTodos(Func<T, bool> predicado)
        {
            return dao.Selecionar().Where(x => !x.Excluido).Where(predicado);
        }

        public virtual IEnumerable<T> ObterTodosDesativados()
        {
            return ObterTodos(x => !(x as ObjetoBase).Ativo);
        }

        public virtual IEnumerable<T> ObterTodosExcluidos()
        {
            return dao.Selecionar(x => x.Excluido);
        }

        public IEnumerable<T> ObterTodosExcluidos(Func<T, bool> predicado)
        {
            return dao.Selecionar(x => x.Excluido).Where(predicado);
        }

        public virtual T Obter(Guid id)
        {
            try
            {
                return dao.Selecionar(x => !x.Excluido && x.Id == id).First();
            }
            catch (InvalidOperationException ex)
            {
                throw new ObjetoNaoRegistradoExcecao("O repositório retornou uma exceção. Pode ser que a identidade informada ainda não tenha sido registrada.", ex);
            }
            catch (ArgumentNullException ex)
            {
                throw new ModeloInvalidoExcecao("Não foi informada uma identidade válida.", ex);
            }
        }

        public virtual T Registrar(T obj)
        {
            if (obj == null)
                throw new ArgumentNullException($"Deve ser informado um registro válido e não nulo para ser registrado no repositório.");

            obj = AntesDeRegistrar?.Invoke(obj) ?? obj;
            if (Registrado(obj))
                throw new BllExcecao($"Já existe um registro com estes dados.\nRegistro: {obj.ToString()}");

            if (RegistradoEExcluido(obj))
                throw new BllExcecao($"Já existe um registro com estes dados. No entanto ele foi excluido. Exclua-o permanentemente primeiro.\nRegistro: {obj.ToString()}");

            dao.Inserir(obj);

            obj = DepoisDeRegistrar?.Invoke(obj) ?? obj;

            return obj;
        }

        public bool Registrado(Guid id)
        {
            return ObterTodos().Any(x => !x.Excluido && x.Id.Equals(x.Id));
        }

        public bool Registrado(T obj)
        {
            return ObterTodos(x => x.Equals(obj)).Any();
        }

        public bool RegistradoEExcluido(T obj)
        {
            var excluidos = ObterTodosExcluidos(x => x.Equals(obj));
            return excluidos.Any();
        }

        public bool RegistradoEExcluido(Guid id)
        {
            var excluidos = ObterTodosExcluidos(x => x.Id.Equals(id));
            return excluidos.Any();
        }

        public virtual T Modificar(T obj)
        {
            T o;
            try
            {
                o = Obter(obj.Id);
            }
            catch (ObjetoNaoRegistradoExcecao ex)
            {
                throw new ObjetoNaoRegistradoExcecao($"Não é possível modificar o registro '{obj.ToString()}' no repositório.", ex);
            }

            AntesDeModificar?.Invoke(obj);

            obj = dao.Alterar(obj);
            return obj;
        }

        public virtual void Excluir(T obj)
        {
            var o = Obter(obj.Id);
            o.Excluir();
            dao.Alterar(o);
        }

        public virtual void Excluir(Guid id)
        {
            var o = Obter(id);
            o.Excluir();
            dao.Alterar(o);
        }

        public virtual T Desativar(T obj)
        {
            obj.Desativar();
            obj = Modificar(obj);
            return obj;
        }

        public void ConfirmarAtualizacoes()
        {
            dao.SalvarAlteracoes();
        }

        public void FecharRepositorio()
        {
            dao.FecharConexao();
        }

        public void AbrirRepositorio()
        {
            dao.AbrirConexao();
        }

        public void ExcluirPermanentemente(Guid id)
        {
            dao.Deletar(id);
        }

        public void ExcluirPermanentemente(T[] obj)
        {
            foreach (var o in obj)
            {
                dao.Deletar(o.Id);
            }
        }
    }
}
