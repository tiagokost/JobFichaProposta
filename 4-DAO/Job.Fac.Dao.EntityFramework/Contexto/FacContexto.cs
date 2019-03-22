using Job.Fac.Bll.Modelo.Candidato.Contato;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Job.Fac.Dao.EntityFramework.Contexto
{
    public class FacContexto : DbContext
    {
        public FacContexto()
            :base("FacContexto")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<HistoryRow>().Property(h => h.MigrationId).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<HistoryRow>().Property(h => h.ContextKey).HasMaxLength(200).IsRequired();

            modelBuilder.Entity<HistoryRow>().HasKey(h => h.MigrationId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Contato> Contatos { get; set; }
    }
}
