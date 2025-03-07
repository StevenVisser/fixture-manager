using FixtureManager.Domain.Interfaces.Daos;
using MediatR;

namespace FixtureManager.Application.Commands.CreateSchool;

internal class CreateSchoolHandler(ISchoolDao schoolDao) : IRequestHandler<CreateSchoolCommand, long>
{
    private readonly ISchoolDao _schoolDao = schoolDao;

    public async Task<long> Handle(CreateSchoolCommand request, CancellationToken cancellationToken)
    {
        return await _schoolDao.CreateSchool(request);
    }
}
