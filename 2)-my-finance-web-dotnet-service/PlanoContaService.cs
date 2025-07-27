
using Microsoft.EntityFrameworkCore;
using my_finance_web_dotnet_Entities;
using my_finance_web_dotnet_infra;
using my_finance_web_dotnet_service.Interfaces;

namespace my_finance_web_dotnet_service
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly MyFinanceDbContent _dbContext;

        public PlanoContaService(MyFinanceDbContent dbContext)
        {
            _dbContext = dbContext;

        }
        public void Cadastrar(PlanoConta Entidade)
        {
            var dbSet = _dbContext.PlanoConta;
            if (Entidade.Id == null)
            {
                dbSet.Add(Entidade);
            }
            else
            {
                dbSet.Attach(Entidade);
                _dbContext.Entry(Entidade).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();
        }

        public void Excluir(int Id)
        {
            var PlanoConta = new PlanoConta() { Id = Id };
            _dbContext.Attach(PlanoConta);
            _dbContext.Remove(PlanoConta);
            _dbContext.SaveChanges();
        }

        public List<PlanoConta> ListarRegistros()
        {
            var dbSet = _dbContext.PlanoConta;
            return dbSet.ToList();
        }

        public PlanoConta RetornarRegistros(int Id)
        {
            return _dbContext.PlanoConta.Where(x => x.Id == Id).First();
        }

    }
}