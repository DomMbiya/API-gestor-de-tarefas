using Gestor_de_tarefas.Integração.Response;

namespace Gestor_de_tarefas.Integração.Interface
{
    public interface IViaCepIntegracao
    {
        Task<ViaCepResponse> ObterDadosViaCep(string cep);
    }
}
