using cadastroWeb.Models;
using cadastroWeb.Service.FuncService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cadastroWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncController : ControllerBase
    {   
        private readonly IFuncInterface _funcInterface;
        public FuncController(IFuncInterface funcInterface) 
        {
            _funcInterface = funcInterface;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FuncModel>>>> Get() 
        {
            return Ok(await _funcInterface.GetFunc());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<FuncModel>>> GetById(int id)
        {
            ServiceResponse<FuncModel> serviceResponse = await _funcInterface.GetFuncById(id);
            return Ok(serviceResponse);
           
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<FuncModel>>>> CriarFunc(FuncModel func)
        {
            return Ok(await _funcInterface.CriacaoFunc(func));
        }
        [HttpPut("UpdateFunc")]
        public async Task<ActionResult<ServiceResponse<List<FuncModel>>>> Update(FuncModel func)
        {
            ServiceResponse<List<FuncModel>> serviceResponse = await _funcInterface.UpdateFunc(func);
            return Ok(serviceResponse);


        }
        [HttpPut("InativFunc")]
        public async Task<ActionResult<ServiceResponse<List<FuncModel>>>> Inativa(int id)
        {
            ServiceResponse<List<FuncModel>> serviceResponse = await _funcInterface.InativaFunc(id);
            return Ok(serviceResponse);


        }
        [HttpPut("AtivaFunc")]
        public async Task<ActionResult<ServiceResponse<List<FuncModel>>>> Ativa(int id)
        {
            ServiceResponse<List<FuncModel>> serviceResponse = await _funcInterface.AtivaFunc(id);
            return Ok(serviceResponse);


        }
        
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<FuncModel>>>> Delete(int id)
        {
            ServiceResponse<List<FuncModel>> serviceResponse = await _funcInterface.DeleteFunc(id);
            return Ok(serviceResponse);


        }
    }
}
