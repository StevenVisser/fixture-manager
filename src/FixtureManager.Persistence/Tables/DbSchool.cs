using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FixtureManager.Persistence.Tables;

[Table("school")]
public class DbSchool
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("province")]
    public string Province { get; set; } = string.Empty;
}
