using System;
using System.Collections.Generic;

namespace FLDAPI.Models;

public partial class Entry
{
    public long Id { get; set; }

    public string Word { get; set; } = null!;

    public string Plural { get; set; } = null!;

    public string PartOfSpeech { get; set; } = null!;

    public string Tenses { get; set; } = null!;

    public string Compare { get; set; } = null!;

    public List<string> Definitions { get; set; } = null!;

    public List<string> Synonyms { get; set; } = null!;

    public List<string> Antonyms { get; set; } = null!;

    public List<string> Hypernyms { get; set; } = null!;

    public List<string> Hyponyms { get; set; } = null!;

    public List<string> Homophones { get; set; } = null!;
}
