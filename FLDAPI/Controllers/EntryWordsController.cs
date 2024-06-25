using Microsoft.AspNetCore.Mvc;

namespace FLDAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EntriesController : ControllerBase{
    
    [HttpGet("similar/{word}")]
    public IActionResult GetSimilarEntryWords(string word){
        return Ok();
    }

    [HttpGet("exists/{word}")]
    public IActionResult WordExists(string word){
        return Ok();
    }

    [HttpGet("random")]
    public IActionResult GetRandomWord(){
        return Ok();
    }

    [HttpGet("previous/{word}")]
    public IActionResult GetPreviousWords(string word){
        return Ok();
    }

    [HttpGet("next/{word}")]
    public IActionResult GetNextWords(string word){
        return Ok();
    }

    [HttpGet("words/{word}")]
    public IActionResult GetEntryWords(string word){
        return Ok();
    }
    
    [HttpGet("entries/{word}")]
    public IActionResult GetAllEntriesForWord(string word){
        return Ok();
    }
}