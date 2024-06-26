using FLDAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Npgsql;

namespace FLDAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EntryWordsController(
    DictionaryContext dictionaryContext,
    ILogger<EntryWordsController> logger) : ControllerBase{
    
    [HttpGet("similar/{word}")]
    public async Task<IActionResult> GetSimilarEntryWords(string word){
        if (string.IsNullOrEmpty(word)){
            return BadRequest("Word parameter cannot be empty.");
        }

        try{
            var entryWords = await dictionaryContext.EntryWords
                .Where(e => EF.Functions.ILike(e.Word, $"{word}%"))
                .Take(5).ToListAsync();

            if (entryWords.IsNullOrEmpty()){
                return NotFound("No similar entries found.");
            }

            return Ok(entryWords);
        }
        catch (Exception ex){
            logger.LogError(ex, "An error occurred while processing your request.");
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    [HttpGet("random")]
    public async Task<IActionResult> GetRandomWord(){
        try{
            var randomEntryWord = await dictionaryContext.EntryWords
                .FromSqlRaw("SELECT * FROM entry_words ORDER BY RANDOM() LIMIT 1")
                .FirstOrDefaultAsync();


            if (randomEntryWord is null){
                return NotFound("Could not obtain random word");
            }

            return Ok(randomEntryWord);
        }
        catch (Exception ex){
            logger.LogError(ex, "An error occurred while processing your request.");
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    [HttpGet("preceding/{word}")]
    public async Task<IActionResult> GetPrecedingWords(string word){
        if (string.IsNullOrEmpty(word)){
            return BadRequest("Word parameter cannot be empty.");
        }

        try{
            EntryWord? entryWord = await dictionaryContext.EntryWords
                .FirstOrDefaultAsync(e => e.Word.ToLower() == word.ToLower());

            if (entryWord == null){
                return NotFound("Could not find the requested word.");
            }

            var precedingRowsQuery = @"
                SELECT * FROM entry_words 
                WHERE id < @Id 
                ORDER BY id DESC 
                LIMIT 10";

            var precedingRows = await dictionaryContext.EntryWords
                .FromSqlRaw(precedingRowsQuery, new NpgsqlParameter("@Id", entryWord.Id))
                .ToListAsync();

            if (precedingRows.Count == 0){
                return NotFound("Could not obtain preceding words.");
            }

            return Ok(precedingRows);
        }
        catch (Exception ex){
            logger.LogError(ex, "An error occurred while processing your request.");
            return StatusCode(500, "An unexpected error occurred while processing your request.");
        }
    }

    [HttpGet("succeeding/{word}")]
    public async Task<IActionResult> GetSucceedingWords(string word){
        if (string.IsNullOrEmpty(word)){
            return BadRequest("Word parameter cannot be empty.");
        }

        try{
            EntryWord? entryWord = await dictionaryContext.EntryWords
                .FirstOrDefaultAsync(e => e.Word.ToLower() == word.ToLower());

            if (entryWord == null){
                return NotFound("Could not find the requested word.");
            }

            var succeedingRowsQuery = @"
                SELECT * FROM entry_words 
                WHERE id > @Id 
                ORDER BY id ASC 
                LIMIT 10";

            var succeedingRows = await dictionaryContext.EntryWords
                .FromSqlRaw(succeedingRowsQuery, new NpgsqlParameter("@Id", entryWord.Id))
                .ToListAsync();

            if (succeedingRows.Count == 0){
                return NotFound("Could not obtain succeeding words.");
            }

            return Ok(succeedingRows);
        }
        catch (Exception ex){
            logger.LogError(ex, "An error occurred while processing your request.");
            return StatusCode(500, "An unexpected error occurred while processing your request.");
        }
    }
}