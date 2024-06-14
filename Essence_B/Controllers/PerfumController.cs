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
            if (await perfumRepository.InsertPerfum(perfum))
            {
                ResponseDto response = new ResponseDto(true, "Insertado Correctamente", perfumRepository.searchIdPerfum(perfum));
                return Ok(response);
            }
            else
            {
                ResponseDto response = new ResponseDto(false, "Error al insertar el perfume");
                return BadRequest(response);
            }
        }
        [HttpPost]
        [Route("InsertPerfumNote")]
        public async Task<IActionResult> InsertPerfumNote(PerfumNote dto)
        {
            if (await perfumRepository.InsertPerfumNote(dto))
            {
                ResponseDto response = new ResponseDto(true, "Insertado Correctamente");
                return Ok(response);
            }
            else
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
            if (perfums.ToArray().Length != 0)
            {
                return Ok(perfums);
            }
            return NotFound(new ResponseDto(false, "No se encontró información"));
        }
    }
}
