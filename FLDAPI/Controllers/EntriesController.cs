﻿using Microsoft.AspNetCore.Mvc;

namespace FLDAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EntriesController : ControllerBase{
    [HttpGet("{word}")]
    public IActionResult GetSimilarEntryWords(string word){
        return Ok();
    }
}