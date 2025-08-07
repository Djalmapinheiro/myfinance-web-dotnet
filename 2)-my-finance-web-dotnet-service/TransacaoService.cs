
using Microsoft.EntityFrameworkCore;
using my_finance_web_dotnet_Entities;
using my_finance_web_dotnet_infra;
using my_finance_web_dotnet_service.Interfaces;

namespace my_finance_web_dotnet_service
{
    public class TransacaoService : ITransacaoService
    {
        private readonly MyFinanceDbContent _dbContext;

        public TransacaoService(MyFinanceDbContent dbContext)
        {
            _dbContext = dbContext;

        }
        public void Cadastrar(Transacao Entidade)
        {
            var dbSet = _dbContext.Transacao;
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
            var Transacao = new Transacao() { Id = Id };
            _dbContext.Attach(Transacao);
            _dbContext.Remove(Transacao);
            _dbContext.SaveChanges();
        }

        public List<Transacao> ListarRegistros()
        {
            var dbSet = _dbContext.Transacao.Include(X => X.PlanoConta);
            return dbSet.ToList();
        }

        public PlanoConta RetornarRegistros(int Id)
        {
            return _dbContext.PlanoConta.Where(x => x.Id == Id).First();
        }

        List<Transacao> ITransacaoService.ListarRegistros()
        {
            throw new NotImplementedException();
        }

        Transacao ITransacaoService.RetornarRegistros(int Id)
        {
            throw new NotImplementedException();
        }
    }
}