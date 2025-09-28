using ColetaAPI.Models;
using ColetaAPI.Service.ColetaService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ColetaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColetaController : ControllerBase
    {
        private readonly IColetaInterface _coletaInterface;
        public ColetaController(IColetaInterface coletaInterface)
        {
            _coletaInterface = coletaInterface;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<ColetaModel>>>> GetColeta()
        {
            return Ok(await _coletaInterface.GetColeta());
        }
        [HttpGet("GetSingle/{id}")]
        public async Task<ActionResult<ServiceResponse<ColetaModel>>> GetSingleColeta(int id)
        {
            return Ok(await _coletaInterface.GetSingleColeta(id));
        }
        [HttpPost("Add")]
        public async Task<ActionResult<ServiceResponse<List<ColetaModel>>>> AddColeta(ColetaModel coleta)
        {
            return Ok(await _coletaInterface.AddColeta(coleta));
        }
        [HttpPut("Update")]
        public async Task<ActionResult<ServiceResponse<ColetaModel>>> UpdateColeta(ColetaModel coleta)
        {
            return Ok(await _coletaInterface.UpdateColeta(coleta));
        }
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<ServiceResponse<List<ColetaModel>>>> DeleteColeta(int id)
        {
            return Ok(await _coletaInterface.DeleteColeta(id));
        }
    }
}
