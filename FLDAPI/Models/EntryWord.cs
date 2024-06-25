using System.ComponentModel.DataAnnotations;

namespace FLDAPI.Models;

public class EntryWord{
    [Key]
    public long Id{ get; set; }
    public string Word{ get; } = string.Empty;
}