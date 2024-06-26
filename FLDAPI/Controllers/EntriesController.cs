using FLDAPI.DTOs;
using FLDAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FLDAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EntriesController(
    DictionaryContext dictionaryContext,
    ILogger<EntryWordsController> logger) : ControllerBase{
    [HttpGet("{word}")]
    public async Task<IActionResult> GetEntries(string word){
        if (string.IsNullOrEmpty(word)){
            return BadRequest("Word parameter cannot be empty.");
        }

        try{
            var entries = await dictionaryContext.Entries
                .Where(e => e.Word.ToLower() == word.ToLower())
                .ToListAsync();

            if (entries.IsNullOrEmpty()){
                return NotFound("No entries found.");
            }

            return Ok(entries.ToDto());
        }
        catch (Exception ex){
            logger.LogError(ex, "An error occurred while processing your request.");
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
}