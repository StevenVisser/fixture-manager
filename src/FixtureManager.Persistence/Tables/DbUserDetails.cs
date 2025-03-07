using FixtureManager.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace FixtureManager.Persistence.Tables;

[Table("user_details")]
public class DbUserDetails
{
    [Column("id")]
    public long Id { get; set; }

    [Column("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [Column("last_name")]
    public string LastName { get; set; } = string.Empty;

    [Column("username")]
    public string Username { get; set; } = string.Empty;

    [Column("password_hash")]
    public string PasswordHash { get; set; } = string.Empty;

    [Column("email")]
    public string Email { get; set; } = string.Empty;

    [Column("mobile_number")]
    public string MobileNumber { get; set; } = string.Empty;

    [Column("country_code")]
    public string CountryCode { get; set; } = string.Empty;

    [Column("type")]
    public UserType Type { get; set; }

    [Column("school_id")]
    public long SchoolId { get; set; }
}
