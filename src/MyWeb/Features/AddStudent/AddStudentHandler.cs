using MediatR;
using MyWeb.Services;

namespace MyWeb.Features.AddStudent;

public class AddStudentHandler : IRequestHandler<AddStudentCommand, Result<bool>> {
    private readonly DbService _dbService;

    public AddStudentHandler(DbService dbService) {
        _dbService = dbService;
    }

    public async Task<Result<bool>> Handle(AddStudentCommand request, CancellationToken cancellationToken) {
        var student = new Student {
            Email = request.Email,
            FirstName = request.FirstName,
            LatName = request.LastName
        };
        var result = _dbService.AddStudent(student);
        return await Task.FromResult(result);
    }
}
