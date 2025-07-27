using my_finance_web_dotnet_Entities;

namespace my_finance_web_dotnet_service.Interfaces
{
    public interface ITransacaoService
    {
        void Cadastrar(Transacao Entidade);
        void Excluir(int Id);
        List<Transacao> ListarRegistros();
        Transacao RetornarRegistros(int Id);

}
}