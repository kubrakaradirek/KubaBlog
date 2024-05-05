using Microsoft.EntityFrameworkCore;

namespace KubaBlogApi.DataAccessLayer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=MONSTER\\MSSQLSERVERR;initial Catalog=KubaBlogApiDB; User=sa;Password=622622aA.");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
