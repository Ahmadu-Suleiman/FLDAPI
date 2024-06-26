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

    private static List<String>? ToList(String? jsonArray){
        return jsonArray is null ? null : JsonConvert.DeserializeObject<List<String>>(jsonArray);
    }
}