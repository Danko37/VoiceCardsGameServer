using System.Text;
using System.Text.Json;

public class GetUserMiddleware
{
    private readonly RequestDelegate _next;
    private readonly UsersService _usersService;

    public GetUserMiddleware(RequestDelegate next, UsersService usersService)
    {
        _next = next;
        _usersService = usersService;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        StringBuilder result = new StringBuilder();
        _usersService.GetAllUsers().ForEach(user =>
        {
            var userText = JsonSerializer.Serialize(user);
            result.Append(userText);
            result.AppendLine();
        });
        await context.Response.WriteAsync(result.ToString());
    }
}

public class SetUserMiddleware
{
    private readonly RequestDelegate _next;
    private readonly UsersService _usersService;

    public SetUserMiddleware(RequestDelegate next, UsersService usersService)
    {
        _next = next;
        _usersService = usersService;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var user = context.Request.Form.First();
        
        _usersService.SetUer(new User(user.Key,user.Value.ToString()));

        await context.Response.WriteAsync("ok");
    }
}