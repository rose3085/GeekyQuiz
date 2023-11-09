global using GeekyQuiz.Models;
global using GeekyQuiz.Services.LoginServices;
global using Microsoft.EntityFrameworkCore;
global using GeekyQuiz.Data;
global using GeekyQuiz.Services.QuestionServices;
//global using GeekyQuiz.Services.UserAnswerServices;
global using GeekyQuiz.Services.UserAnswerServices;
global using GeekyQuiz.Services.ChoiceServices;
using GeekyQuiz.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHostedService<BackgroundWorkerServices>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILoginServices, LoginServices>();
builder.Services.AddScoped<IQuestionServices, QuestionServices>();
builder.Services.AddScoped<IUserAnswerServices, UserAnswerServices>();
builder.Services.AddScoped<IChoiceServices, ChoiceServices>();
//builder.Services.AddAutoMapper(typeof(Program).Assembly);
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

