using CV.ClassLibrary.Data;
using CV.ClassLibrary.Models;
using MongoDB.Driver;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
MongoDBService db = new MongoDBService("CVDB");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/skills", async () =>
{
    try
    {
        var listOfSkills = await db.GetAllAsync("Skills");
        return Results.Ok(listOfSkills);
    }
    catch (Exception)
    {
        return Results.NotFound("Could not get all Skills");
    }
});

app.MapGet("/skill/{id}", async (string id) =>
{
    try
    {
        var skill = await db.GetByIDAsync("Skills", id);
        return Results.Ok(skill);
    }
    catch (Exception e)
    {
        return Results.NotFound("Could not find skill by ID " + e.Message);
    }
});

app.MapPost("/skill", async (Skills newSkill) =>
{
    try
    {
        await db.AddAsync("Skills", newSkill);
        return Results.Ok(newSkill);
    }
    catch(Exception e) 
    {
        return Results.NotFound("Could not add new skill " + e.Message);
    }
});

app.MapPut("/skill/{id}", async (string id, Skills updatedSkill) =>
{
    try
    {
        await db.UpdateAsync("Skills", updatedSkill, id);
        return Results.Ok(updatedSkill);
    }
    catch(Exception e)
    {
        return Results.NotFound("Could not update Skill " + e.Message);
    }

});

app.MapDelete("/skill/{id}", async (string id) =>
{
    try
    {
        await db.DeleteAsync("Skills", id);
        return Results.Ok("Delete successful");
    }
    catch (Exception e)
    {
        return Results.NotFound("Could not delete Skill " + e.Message);
    }
});



app.Run();


