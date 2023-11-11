using MediatR;
using MyWeb.Services;

namespace MyWeb.Features.GetStudent;

public class GetStudentHandler : IRequestHandler<GetStudentQuery, Result<Student>> {
    private readonly DbService _dbService;

    public GetStudentHandler(DbService dbService) {
        _dbService = dbService;
    }

    public Task<Result<Student>> Handle(GetStudentQuery request, CancellationToken cancellationToken) {
        return Task.FromResult(_dbService.GetStudent(request.Email));
    }
}
