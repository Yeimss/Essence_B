using Essence_B.Models.Domain.notes;
using Essence_B.Models.Domain.Perfums;
using Essence_B.Models.Domain.Utilities;
using Essence_B.Repositories.Implementation;
using Essence_B.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Essence_B.Controllers
{
    [Route("api/Perfum")]
    [ApiController]
    public class PerfumController : ControllerBase
    {
        private readonly IPerfumRepository perfumRepository;
        public PerfumController(IPerfumRepository _perfumRepository)
        {
            this.perfumRepository = _perfumRepository;
        }

        [HttpPost]
        [Route("InsertPerfum")]
        public async Task<IActionResult> InsertPerfum(PerfumDto perfum)
        {
            if (perfumRepository.InsertPerfum(perfum))
            {
                ResponseDto response = new ResponseDto(true, "Insertado Correctamente");
                return Ok(response);
            }else
            {
                ResponseDto response = new ResponseDto(false, "Error al insertar el perfume");
                return BadRequest(response);
            }
        }
        [Route("getAllPerfums")]
        [HttpGet]
        public IActionResult getAllPerfums()
        {
            List<object> perfums = new List<object>();
            perfums = perfumRepository.getAllPerfums();
            if (perfums.Count != 0)
            {
                ResponseDto response = new ResponseDto(true, "Insertado Correctamente", perfums);
                return Ok(response);
            }
            else
            {
                ResponseDto response = new ResponseDto(false, "No se encontraron registros");
                return NotFound(response);
            }
        }
    }
}
