using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FixtureManager.Persistence.Tables;

[Table("fixture")]
public class DbFixture
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("date_time")]
    public DateTime DateTime { get; set; }

    [Column("location")]
    public string Location { get; set; } = string.Empty;
}
