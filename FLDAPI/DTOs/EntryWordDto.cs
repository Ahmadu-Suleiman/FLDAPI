using System.ComponentModel.DataAnnotations;

namespace FLDAPI.Models;

public class EntryWord{
    [Key]
    public string Id{ get; } = string.Empty;
    public string Word{ get; } = string.Empty;
}