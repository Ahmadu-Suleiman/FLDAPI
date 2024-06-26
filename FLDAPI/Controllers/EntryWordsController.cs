﻿using FLDAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Npgsql;

namespace FLDAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EntryWordsController(DictionaryContext dictionaryContext,
    ILogger<EntryWordsController> logger) : ControllerBase{
    
    private readonly DictionaryContext _dictionaryContext = dictionaryContext;
    private readonly ILogger<EntryWordsController> _logger = logger;

    [HttpGet("similar/{word}")]
    public async Task<IActionResult> GetSimilarEntryWords(string word){
        String w = word;
        if (string.IsNullOrEmpty(word)){
            return BadRequest("Word parameter cannot be empty.");
        }

        try{
            var entryWords =await _dictionaryContext.EntryWords
                .Where(e => EF.Functions.ILike(e.Word, $"{word}%"))
                .Take(5).ToListAsync();

            if (entryWords.IsNullOrEmpty()){
                return NotFound("No similar entries found.");
            }

            return Ok(entryWords);
        }catch (Exception ex){
            _logger.LogError(ex, "An error occurred while processing your request.");
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    [HttpGet("random")]
    public async Task<IActionResult> GetRandomWord(){
        try{
            EntryWord? randomEntryWord = await _dictionaryContext.EntryWords
                .FromSqlRaw("SELECT * FROM entry_words ORDER BY RANDOM() LIMIT 1")
                .FirstOrDefaultAsync();


            if (randomEntryWord is null){
                return NotFound("Could not obtain random word");
            }

            return Ok(randomEntryWord);
        }
        catch (Exception ex){
            _logger.LogError(ex, "An error occurred while processing your request.");
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    [HttpGet("preceding/{word}")]
    public async Task<IActionResult> GetPrecedingWords(string word){
        if (string.IsNullOrEmpty(word)){
            return BadRequest("Word parameter cannot be empty.");
        }
        
        try{
            EntryWord? entryWord = await _dictionaryContext.EntryWords
                .FirstOrDefaultAsync(e => e.Word.Equals(word, StringComparison.OrdinalIgnoreCase));

            if (entryWord == null){
                return NotFound("Could not find the requested word.");
            }

            var precedingRowsQuery = @"
            SELECT * FROM entry_words 
            WHERE id < Id 
            ORDER BY id DESC 
            LIMIT 20";

            var precedingRows = await _dictionaryContext.EntryWords
                .FromSqlRaw(precedingRowsQuery, new NpgsqlParameter("Id", entryWord.Id))
                .ToListAsync();

            if (precedingRows.Count == 0){
                return NotFound("Could not obtain preceding words.");
            }

            return Ok(precedingRows);
        }
        catch (Exception ex){
            _logger.LogError(ex, "An error occurred while processing your request.");
            return StatusCode(500, "An unexpected error occurred while processing your request.");
        }
    }
    
    [HttpGet("succeeding/{word}")]
    public async Task<IActionResult> GetSucceedingWords(string word){
        if (string.IsNullOrEmpty(word)){
            return BadRequest("Word parameter cannot be empty.");
        }
        
        try{
            EntryWord? entryWord = await _dictionaryContext.EntryWords
                .FirstOrDefaultAsync(e => e.Word.Equals(word, StringComparison.OrdinalIgnoreCase));

            if (entryWord == null){
                return NotFound("Could not find the requested word.");
            }

            var precedingRowsQuery = @"
            SELECT * FROM entry_words 
            WHERE id > Id 
            ORDER BY id DESC 
            LIMIT 20";

            var succeedingRows = await _dictionaryContext.EntryWords
                .FromSqlRaw(precedingRowsQuery, new NpgsqlParameter("Id", entryWord.Id))
                .ToListAsync();

            if (succeedingRows.Count == 0){
                return NotFound("Could not obtain succeeding words.");
            }

            return Ok(succeedingRows);
        }
        catch (Exception ex){
            _logger.LogError(ex, "An error occurred while processing your request.");
            return StatusCode(500, "An unexpected error occurred while processing your request.");
        }
    }
}