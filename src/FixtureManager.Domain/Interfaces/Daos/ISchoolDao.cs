using FixtureManager.Domain.Models;
using FixtureManager.Domain.Models.Requests;

namespace FixtureManager.Domain.Interfaces.Daos;

public interface ISchoolDao
{
    Task<long> CreateSchool(School school);
    Task<School> GetSchoolByNameAsync(string name); // TODO: Add Unique constraint to school name
    Task<School> GetSchoolByIdAsync(long id);
    Task DeleteSchoolByNameAsync(string name);
    Task DeleteSchoolByIdAsync(long id);
    Task<School> UpdateSchoolAsync(UpdateSchoolRequest request);
}
