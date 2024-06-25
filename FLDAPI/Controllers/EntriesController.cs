using Microsoft.AspNetCore.Mvc;

namespace FLDAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EntriesController : ControllerBase{
    
    [HttpGet("entries/{word}")]
    public IActionResult GetAllEntriesForWord(string word){
        return Ok();
    }
}