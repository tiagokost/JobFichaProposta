using Job.Fac.Bll.Modelo.Candidato.Contato;
using Job.Fac.Dao.Candidato;
using Job.Fac.Dao.EntityFramework.Nucleo;
using System.Data.Entity;

namespace Job.Fac.Dao.EntityFramework.Candidato
{
    public class ContatoDaoEf : BaseDao<Contato>, IContatoDao
    {
        public ContatoDaoEf(DbContext contexto)
            :base(contexto)
        {

        }
    }
}
