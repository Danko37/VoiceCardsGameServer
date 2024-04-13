var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<UsersService>();

var app = builder.Build();

app.Map("/get_users",context =>
{
    context.UseMiddleware<GetUserMiddleware>();
});

app.Map("/set_user", context =>
{
    context.UseMiddleware<SetUserMiddleware>();
});

app.Run(context => context.Response.WriteAsync("ok"));

app.Run();