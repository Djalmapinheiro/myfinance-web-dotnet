using my_finance_web_dotnet_Entities;

namespace my_finance_web_dotnet_service.Interfaces
{
    public interface IPlanoContaService
    {
        void Cadastrar(PlanoConta Entidade);
        void Excluir(int Id);
        List<PlanoConta> ListarRegistros();
        PlanoConta RetornarRegistros(int Id);

}
}