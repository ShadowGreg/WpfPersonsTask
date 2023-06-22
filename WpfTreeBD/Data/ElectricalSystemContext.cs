using System.Data.Entity;
using System.Data.SQLite;
using System.Data.Entity.ModelConfiguration.Conventions;
using WpfTreeBD.Core;

namespace WpfTreeBD.Data {
    public class ElectricalSystemContext : DbContext {
        public ElectricalSystemContext() : base(new SQLiteConnection()
        {
            ConnectionString = new SQLiteConnectionStringBuilder()
            {
                DataSource = "ElectricalSystem.db",
                ForeignKeys = true
            }.ConnectionString
        }, true)
        {
        }
        public DbSet<ElectricalSystem> ElectricalSystems { get; set; }
        public DbSet<ElectricPanel> ElectricPanels { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}