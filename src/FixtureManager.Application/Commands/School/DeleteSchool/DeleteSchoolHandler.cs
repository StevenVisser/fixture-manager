using FixtureManager.Domain.Interfaces.Daos;
using MediatR;

namespace FixtureManager.Application.Commands.DeleteSchool;

internal class DeleteSchoolHandler(ISchoolDao schoolDao) : IRequestHandler<DeleteSchoolCommand> // TODO: Add Validators for commands
{
    private readonly ISchoolDao _schoolDao = schoolDao;

    public async Task Handle(DeleteSchoolCommand request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(request.Name))
            await _schoolDao.DeleteSchoolByNameAsync(request.Name);
        else
            await _schoolDao.DeleteSchoolByIdAsync((long)request.Id!);
    }
}
