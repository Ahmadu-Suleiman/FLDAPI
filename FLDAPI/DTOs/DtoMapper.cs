using FLDAPI.Models;
using Newtonsoft.Json;

namespace FLDAPI.DTOs;

public static class DtoMapper{
    public static EntryWordDto ToDto(this EntryWord entryWord){
        return new EntryWordDto(entryWord.Word);
    }

    public static EntryDto ToDto(this Entry entry){
        return new EntryDto(
            entry.Word,
            entry.PartOfSpeech,
            entry.Plural,
            ToList(entry.Tenses),
            ToList(entry.Compare),
            ToList(entry.Definitions)!,
            ToList(entry.Synonyms),
            ToList(entry.Antonyms),
            ToList(entry.Hypernyms),
            ToList(entry.Hyponyms),
            ToList(entry.Homophones)
        );
    }

    public static List<EntryWordDto> ToDto(this List<EntryWord> entryWords){
        return entryWords.Select(entryWord => new EntryWordDto(entryWord.Word)).ToList();
    }

    public static List<EntryDto> ToDto(this List<Entry> entries){
        return entries.Select(entry => new EntryDto(
            entry.Word,
            entry.PartOfSpeech,
            entry.Plural,
            ToList(entry.Tenses),
            ToList(entry.Compare),
            ToList(entry.Definitions)!,
            ToList(entry.Synonyms),
            ToList(entry.Antonyms),
            ToList(entry.Hypernyms),
            ToList(entry.Hyponyms),
            ToList(entry.Homophones))).ToList();
    }


    private static List<String>? ToList(String? jsonArray){
        return jsonArray is null ? null : JsonConvert.DeserializeObject<List<String>>(jsonArray);
    }
}