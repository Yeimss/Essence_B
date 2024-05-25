using Essence_B.Models.Domain.notes;
using Essence_B.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Essence_B.Controllers
{
    [Route("api/notes")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository noteRepository;
        public NotesController(INoteRepository note)
        {
            this.noteRepository = note;
        }
        [Route("getNotes")]
        [HttpGet]
        public async Task<IActionResult> getNotes()
        {
            List<NoteDto> response = new List<NoteDto>();
            response = noteRepository.getNotes();
            return Ok(response);
        }
        [Route("getNoteTypes")]
        [HttpGet]
        public async Task<IActionResult> getNoteTypes()
        {
            return Ok(noteRepository.getNoteTypes());  
        }
        [Route("getOrigins")]
        [HttpGet]
        public async Task<IActionResult> getHouses()
        {
            return Ok(noteRepository.getHouses());
        }
        [Route("getGenders")]
        [HttpGet]
        public async Task<IActionResult> getGenders()
        {
            return Ok(noteRepository.getGenders());
        }
        [Route("getSizes")]
        [HttpGet]
        public async Task<IActionResult> getSizes()
        {
            return Ok(noteRepository.getSizes());
        }
        [Route("getConcentrations")]
        [HttpGet]
        public async Task<IActionResult> getConcentrations()
        {
            return Ok(noteRepository.getConcentrations());
        }
    }
}
