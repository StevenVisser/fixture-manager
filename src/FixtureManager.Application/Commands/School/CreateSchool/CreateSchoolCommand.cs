using FixtureManager.Domain.Models;
using MediatR;

namespace FixtureManager.Application.Commands.CreateSchool;

public class CreateSchoolCommand : School, IRequest<long> { }