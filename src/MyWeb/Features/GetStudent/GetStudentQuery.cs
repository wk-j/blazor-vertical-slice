using MediatR;
using MyWeb.Services;

namespace MyWeb.Features.GetStudent;

public record GetStudentQuery(string Email) : IRequest<Result<Student>>;
