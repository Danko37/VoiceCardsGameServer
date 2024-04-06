﻿
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
        
    }
}