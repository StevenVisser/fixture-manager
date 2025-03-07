using FixtureManager.Domain.Models;
using MediatR;

namespace FixtureManager.Application.Commands.CreateUser;

public class CreateUserCommand : UserDetail, IRequest<long> { }