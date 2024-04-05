using MediatR;
using MediCenter.Application.Errors;

namespace MediCenter.Application.Commands.UsersCommands.DoctorCommands.DeleteDoctor;

public class DeleteDoctorCommand(Guid id) : IRequest<Result>
{
    public Guid Id { get; set; } = id;
}