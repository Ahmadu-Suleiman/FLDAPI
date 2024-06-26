using System.ComponentModel.DataAnnotations;

namespace FLDAPI.DTOs;

public record EntryDto(String Word, String PartOfSpeech, String? Plural, List<String>? Tenses,
    List<String>? Compare, List<String> Definitions, List<String>? Synonyms,
    List<String>? Antonyms, List<String>? Hypernyms, List<String>? Hyponyms,
    List<String>? Homophones) ;
