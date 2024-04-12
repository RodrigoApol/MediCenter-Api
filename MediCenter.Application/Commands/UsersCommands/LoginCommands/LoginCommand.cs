using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Application.Models.ViewModel;

namespace MediCenter.Application.Commands.UsersCommands.LoginCommands;

public record LoginCommand(
    string Email,
    string Password) : IRequest<Result<LoginViewModel>>;