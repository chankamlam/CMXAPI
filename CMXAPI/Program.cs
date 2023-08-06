using CMXAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// add swagger service
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add DBCTX
var conStr = builder.Configuration.GetConnectionString("MSSQLConnectionString");

builder.Services.AddDbContext<DBCTX>(opts =>
{
    if (!string.IsNullOrEmpty(conStr))
    {
        opts.use(conStr);
    }
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


/**
 *     Demo for CMX
 */

app.MapPost("api/documents/{policyNum}", (IFormFileCollection files, string policyNum) =>
{
    CMXAPI.Common.Fun.StoreFileByPolicyNumber(files, policyNum);
    return Results.Ok();
});

app.MapGet("api/documents/{policyNum}/{fileName}", async (string policyNum, string fileName) => {

    var file = CMXAPI.Common.Fun.GetFileByPolicyNumberAndFileName(policyNum, fileName);
    if (file == null)
    {
        return Results.NoContent();
    }
    return Results.Bytes(await File.ReadAllBytesAsync(file));
});

app.MapGet("api/documents/{policyNum}", (string policyNum) => {
    try
    {
        var files = CMXAPI.Common.Fun.GetFilesByPolicyNumber(policyNum);
        return Results.Ok(files);
    }
    catch (Exception ex)
    {
        System.Console.WriteLine(ex);
        return Results.NoContent();
    }
});


/**
 *      Demo for CMX API With ORM Framework (EF)
 */
//app.MapPost("api/documents/ef/{policyNum}", (IFormFileCollection files, string policyNum) =>
//{
//    CMXAPI.Common.Fun.StoreFileByPolicyNumber(files, policyNum);

//    return Results.Ok();
//});

app.Run();

