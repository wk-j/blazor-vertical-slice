using MediatR;
using Microsoft.AspNetCore.Components;
using MyWeb.Features.AddStudent;

namespace MyWeb.Pages.Features;

public partial class AddStudent : ComponentBase {

    [Inject]
    protected IMediator Mediator { get; set; } = null!;
    [Inject]
    protected ILogger<AddStudent> Logger { get; set; } = null!;

    private string Email { get; set; } = string.Empty;
    private string FirstName { get; set; } = string.Empty;
    private string LastName { get; set; } = string.Empty;

    protected async Task AddStudentAsync() {
        Email = "wk@gmail.com";
        FirstName = $"Wael {DateTime.Now}";
        var result = await Mediator.Send(new AddStudentCommand(Email, FirstName, LastName));
        if (result.IsSuccess) {
            Logger.LogInformation("Student added successfully");
        } else {
            Logger.LogError("Student not added");
            Logger.LogError("Error message: {0}", result.ErrorMessage);
        }
    }
}
