using Gestor_de_tarefas.Integração.Interface;
using Gestor_de_tarefas.Integração.Refit;
using Gestor_de_tarefas.Integração.Response;
using Microsoft.IdentityModel.Tokens;

namespace Gestor_de_tarefas.Integração
{
    public class ViaCepIntegracao : IViaCepIntegracao
    {
        private readonly IViaCepIntegracaoRefit _viaCepIntegracaoRefit;
        public ViaCepIntegracao(IViaCepIntegracaoRefit viaCepIntegracaoRefit)
        {
            _viaCepIntegracaoRefit = viaCepIntegracaoRefit;
        }
        public async Task<ViaCepResponse> ObterDadosViaCep(string cep)
        {
           var respondeData = await _viaCepIntegracaoRefit.ObterDadosViaCep(cep);
            if (respondeData != null && respondeData.IsSuccessStatusCode)
            {
                return respondeData.Content;
            }

           return null;
        }
    }
}
