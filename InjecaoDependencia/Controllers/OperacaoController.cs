using Microsoft.AspNetCore.Mvc;

namespace InjecaoDependencia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperacaoController : ControllerBase
    {
        private readonly IOperacao _operacao;
        private readonly IServiceProvider _provider;


        public OperacaoController(
            IOperacao operacao,
            IServiceProvider provider)
        {
            _operacao = operacao;
        }
        [HttpGet("Constructor")]
        public IActionResult Constructor()
        {
            return Ok(_operacao.Id);
        }

        [HttpGet("Anotacao")]
        public IActionResult Anotacao([FromServices] IOperacao operacao)
        {
            return Ok(operacao.Id);
        }

        [HttpGet("Provider")]
        public IActionResult Provider()
        {
            return Ok(_provider.GetRequiredService<IOperacao>());
        }


    }
}