using FLDAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FLDAPI;

public class DictionaryContext(DbContextOptions<DictionaryContext> options) : DbContext(options){
    
    public DbSet<Entry> Entries{ get; set; }
    public DbSet<EntryWord> EntryWords{ get; set; }
}