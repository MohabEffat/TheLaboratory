using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using IdentityServer;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer()
    .AddInMemoryClients(Config.GetClients)
    .AddInMemoryIdentityResources(Config.GetIdentityResources)
    .AddInMemoryApiResources(Config.GetApiResources)
    .AddInMemoryApiScopes(Config.GetApiScopes)
    .AddTestUsers(Config.GetTestUsers)
    .AddDeveloperSigningCredential();

var app = builder.Build();

app.UseIdentityServer();

app.MapGet("/", () => "Hello World!");

app.Run();
