using System.Globalization;
using Microsoft.AspNetCore.Components.Rendering;

namespace MyWeb.Services;

public class DbService {
    private readonly ILogger<DbService> _logger;
    private static readonly List<Student> _students = new();

    public DbService(ILogger<DbService> logger) {
        _logger = logger;
    }

    public Result<Student> GetStudent(string email) {
        var student = _students.FirstOrDefault(s => s.Email == email);
        if (student is null) {
            return new Result<Student> {
                IsSuccess = false,
                ErrorMessage = string.Format(CultureInfo.InvariantCulture, "Student with email {0} not found", email)
            };
        }

        return new Result<Student> {
            IsSuccess = true,
            Data = student
        };
    }

    public Result<bool> AddStudent(Student student) {
        _students.Add(student);
        return new Result<bool> {
            IsSuccess = true,
            Data = true
        };
    }
}
