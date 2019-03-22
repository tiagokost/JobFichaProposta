using Job.Fac.Bll.Modelo.Base.Argus.Modelo.Nucleo;
using Job.Fac.Bll.Nucleo.Base;
using Job.Fac.Dao.EntityFramework.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace Job.Fac.Dao.EntityFramework.Nucleo
{
    public class BaseDao<T> : IBaseDao<T> where T : ObjetoBase
    {
        private readonly DbContext contexto;

        public BaseDao(DbContext contexto)
        {
            this.contexto = contexto;
        }

        public BaseDao(string conn)
        {
            contexto = Activator.CreateInstance<FacContexto>();
        }

        public T Alterar(T obj)
        {
            obj = contexto.Set<T>().Find(obj.Id);
            contexto.Entry(obj).State = EntityState.Modified;
            return obj;
        }

        public void SalvarAlteracoes()
        {
            try
            {
                contexto.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var str = new StringBuilder();
                if (ex.EntityValidationErrors != null && ex.EntityValidationErrors.Any())
                {
                    foreach (var msg in ex.EntityValidationErrors)
                    {
                        foreach (var i in msg.ValidationErrors)
                            str.AppendLine($"Campo: '{i.PropertyName}', Mensagem: '{i.ErrorMessage}'");
                    }
                }

                throw new Exception($"Não foi possível salvar as alterações no repositório. \nAlgumas das informaçãoes não foram aceitas.\n\n{str.ToString()}", ex);
            }
        }

        public void Deletar(Guid id)
        {
            var o = contexto.Set<T>().FirstOrDefault(x => x.Id.Equals(id));
            contexto.Set<T>().Remove(o);
        }

        public T Inserir(T obj)
        {
            return contexto.Set<T>().Add(obj);
        }

        public IEnumerable<T> Selecionar()
        {
            return contexto.Set<T>();
        }

        public IEnumerable<T> Selecionar(Func<T, bool> predicado)
        {
            return Selecionar().Where(predicado);
        }

        public T Selecionar(Guid id)
        {
            return contexto.Set<T>().FirstOrDefault(x => x.Id.Equals(id));
        }

        public void AbrirConexao()
        {
            contexto.Database.Connection.Open();
        }

        public void FecharConexao()
        {
            contexto.Database.Connection.Close();
        }
    }
}
