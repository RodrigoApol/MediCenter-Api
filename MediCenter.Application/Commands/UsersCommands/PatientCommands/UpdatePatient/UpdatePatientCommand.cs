using MediatR;

namespace MediCenter.Application.Commands.UsersCommands.PatientCommands.UpdatePatient;

public class UpdatePatientCommand(Guid id) : IRequest;