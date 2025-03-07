using FixtureManager.Domain.Interfaces.Daos;
using FixtureManager.Domain.Models;
using MediatR;

namespace FixtureManager.Application.Queries.GetSchool;

internal class GetSchoolHandler(ISchoolDao schoolDao) : IRequestHandler<GetSchoolQuery, School>
{
    private readonly ISchoolDao _schoolDao = schoolDao;

    public async Task<School> Handle(GetSchoolQuery request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(request.Name))
            return await _schoolDao.GetSchoolByNameAsync(request.Name);
        else
            return await _schoolDao.GetSchoolByIdAsync((long)request.Id!);
    }
}
