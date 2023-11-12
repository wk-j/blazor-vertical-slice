using MediatR;
using MyWeb.Services;

namespace MyWeb.Features.AddStudent;

public record AddStudentCommand(string Email, string FirstName, string LastName) : IRequest<Result<bool>>;
