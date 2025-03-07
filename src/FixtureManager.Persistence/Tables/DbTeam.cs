using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FixtureManager.Persistence.Tables;

[Table("team")]
public class DbTeam
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [ForeignKey("coach_id")]
    [Column("coach_id")]
    public long CoachId { get; set; }

    [Column("sport_id")]
    public long SportId { get; set; }

    [ForeignKey("school_id")]
    [Column("school_id")]
    public long SchoolId { get; set; }

    [Column("team_name")]
    public string TeamName { get; set; } = string.Empty;

    [Column("age_group")]
    public string AgeGroup { get; set; } = string.Empty;
}
