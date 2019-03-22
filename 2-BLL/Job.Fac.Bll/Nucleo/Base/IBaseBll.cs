using Job.Fac.Bll.Modelo.Base.Argus.Modelo.Nucleo;
using System;
using System.Collections.Generic;

namespace Job.Fac.Bll.Nucleo.Base
{
    public interface IBaseBll<T> where T : ObjetoBase
    {
        IEnumerable<T> ObterTodos();
        IEnumerable<T> ObterTodosExcluidos();
        IEnumerable<T> ObterTodosExcluidos(Func<T, bool> predicado);
        IEnumerable<T> ObterTodosDesativados();
        IEnumerable<T> ObterTodos(Func<T, bool> predicado);
        T Obter(Guid id);
        T Registrar(T obj);
        bool Registrado(Guid id);
        bool Registrado(T obj);
        bool RegistradoEExcluido(T obj);
        T Modificar(T obj);
        void Excluir(T obj);
        void Excluir(Guid id);
        void ExcluirPermanentemente(Guid id);
        void ExcluirPermanentemente(T[] obj);
        T Desativar(T obj);
        void ConfirmarAtualizacoes();
        void FecharRepositorio();
        void AbrirRepositorio();
    }
}
