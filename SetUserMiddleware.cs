﻿public class SetUserMiddleware
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
        _usersService.CreateUser(new User(context.Request.Form["Name"]!));

        await _next.Invoke(context);
    }
}