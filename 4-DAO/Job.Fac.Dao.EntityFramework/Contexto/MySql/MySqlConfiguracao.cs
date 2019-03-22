using MySql.Data.Entity;
using System.Data.Entity;

namespace Job.Fac.Dao.EntityFramework.Contexto.MySql
{
    public class MySqlConfiguracao : DbConfiguration
    {
        public MySqlConfiguracao()
        {
            SetHistoryContext(
           "MySql.Data.MySqlClient", (conn, schema) => new MySqlHistoriaContexto(conn, schema));
        }
    }
}
