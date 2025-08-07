using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using my_finance_web_dotnet_Entities;

namespace my_finance_web_dotnet_infra;

public class MyFinanceDbContent : DbContext
{
    public DbSet<PlanoConta> PlanoConta { get; set; }
    public DbSet<Transacao> Transacao { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=LOCALHOST\SQLEXPRESS;Database=myfinance;Trusted_Connection=True;Encrypt=False; TrustServerCertificate=False");
    }

}
