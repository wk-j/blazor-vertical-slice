using MediatR;
using Microsoft.AspNetCore.Components;
using MyWeb.Features.GetStudent;

namespace MyWeb.Pages.Features;

public partial class GetStudent : ComponentBase {
    [Inject] protected IMediator Mediator { get; set; } = null!;
    [Inject] protected ILogger<GetStudent> Logger { get; set; } = null!;

    public async Task GetStudentAsync() {
        var result = await Mediator.Send(new GetStudentQuery("wk@gmail.com"));
        if (result.IsSuccess) {
            Logger.LogInformation("Student found successfully");
            Logger.LogInformation("Student email: {0}", result.Data!.Email);
            Logger.LogInformation("Student first name: {0}", result.Data!.FirstName);
        } else {
            Logger.LogError("Student not found");
            Logger.LogError("Error message: {0}", result.ErrorMessage);
        }
    }
}
