
using System;
using System.Collections.Generic;

namespace Job.Fac.Bll.Nucleo.Base
{
    public interface IBaseDao<T>
    {
        T Inserir(T obj);
        T Selecionar(Guid id);
        IEnumerable<T> Selecionar();
        IEnumerable<T> Selecionar(Func<T, bool> predicado);
        T Alterar(T obj);
        void Deletar(Guid id);
        void SalvarAlteracoes();
        void AbrirConexao();
        void FecharConexao();
    }
}
