using System;
using System.Collections.Generic;

namespace FLDAPI.Models;

public class Entry
{
    public long Id { get;  }

    public string Word { get;  } = null!;

    public string? Plural { get;  } = null!;

    public string PartOfSpeech { get;  } = null!;

    public string? Tenses { get;  } = null!;

    public string? Compare { get;  } = null!;

    public string? Definitions { get;  } = null!;

    public string? Synonyms { get;  } = null!;

    public string? Antonyms { get;  } = null!;

    public string? Hypernyms { get;  } = null!;

    public string? Hyponyms { get;  } = null!;

    public string? Homophones { get;  } = null!;
}
