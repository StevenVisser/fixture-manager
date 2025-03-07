using System.ComponentModel.DataAnnotations.Schema;

namespace FixtureManager.Persistence.Tables;

[Table("team_list")]
public class DbTeamList
{
    [ForeignKey("team_id")]
    [Column("team_id")]
    public long TeamId { get; set; }

    [ForeignKey("fixture_id")]
    [Column("fixture_id")]
    public long FixtureId { get; set; }

    [ForeignKey("student_id")]
    [Column("student_id")]
    public long StudentId { get; set; }

    [Column("position_details")]
    public string PositionDetails { get; set; }
}
