using Gestor_de_tarefas.Integração.Interface;
using Gestor_de_tarefas.Integração.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_de_tarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegracao _viaCepIntegracao;

        public CepController(IViaCepIntegracao viaCepIntegracao) 
        { 
            _viaCepIntegracao = viaCepIntegracao;
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<ViaCepResponse>> ListarDadosEndereco(string cep)
        {
            var respondeData = await _viaCepIntegracao.ObterDadosViaCep(cep);
            
            if (respondeData == null)
            {
                return BadRequest("CEP não encontrado");
            }
            return Ok(respondeData);

        }
    }

}
