using System.ComponentModel.DataAnnotations;

namespace FLDAPI.Models;

public class Entry{
    [Key]
    public long Id{ get; set; }
    public string Word{ get; set; } = string.Empty;
    public string Plural{ get; set; } = string.Empty;
    public string PartOfSpeech{ get; set; } = string.Empty;
    public string Tenses{ get; set; } = string.Empty;
    public string Compare{ get; set; } = string.Empty;
    public List<string> Definitions{ get; set; } = new();
    public List<string> Synonyms{ get; set; } = new();
    public List<string> Antonyms{ get; set; } = new();
    public List<string> Hypernyms{ get; set; } = new();
    public List<string> Hyponyms{ get; set; } = new();
    public List<string> Homophones{ get; set; } = new();
}