using Gestor_de_tarefas.Integração.Response;
using Refit;

namespace Gestor_de_tarefas.Integração.Refit
{
    public interface IViaCepIntegracaoRefit
    {
        [Get("/ws/{cep}/json/")]
        Task<ApiResponse<ViaCepResponse>> ObterDadosViaCep(string cep);
    }
}
