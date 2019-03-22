using System.Data.Common;
using System.Data.Entity.Migrations.History;

namespace Job.Fac.Dao.EntityFramework.Contexto.MySql
{
    public class MySqlHistoriaContexto : HistoryContext
    {
        public MySqlHistoriaContexto(DbConnection connection, string defaultSchema)
           : base(connection, defaultSchema)
        {

        }

    }
}
