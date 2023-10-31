global using GeekyQuiz.Models;
global using GeekyQuiz.Services.LoginServices;
global using Microsoft.EntityFrameworkCore;
global using GeekyQuiz.Data;
global using GeekyQuiz.Services.QuestionServices;
//global using GeekyQuiz.Services.UserAnswerServices;
global using GeekyQuiz.Services.UserAnswerServices;
global using GeekyQuiz.Services.ChoiceServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ILoginServices, LoginServices>();
builder.Services.AddTransient<IQuestionServices, QuestionServices>();
builder.Services.AddTransient<IUserAnswerServices, UserAnswerServices>();
builder.Services.AddTransient<IChoiceServices, ChoiceServices>();

builder.Services.AddDbContext<DataContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
