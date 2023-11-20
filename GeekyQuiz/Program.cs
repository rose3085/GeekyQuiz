global using GeekyQuiz.Models;
global using GeekyQuiz.Services.LoginServices;
global using Microsoft.EntityFrameworkCore;
global using GeekyQuiz.Data;
global using GeekyQuiz.Services.QuestionServices;
//global using GeekyQuiz.Services.UserAnswerServices;
global using GeekyQuiz.Services.UserAnswerServices;
global using GeekyQuiz.Services.ChoiceServices;
using GeekyQuiz.Services;
using GeekyQuiz.Cron;
//using GeekyQuiz.Services.TaskSchedulerService;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddHostedService<BackgroundWorkerServices>();

// Add services to the container.
builder.Services.AddCors(options => {
    options.AddPolicy(name: "AllowOrigin", policy => {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddDbContext<DataContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ILoginServices, LoginServices>();
builder.Services.AddTransient<IQuestionServices, QuestionServices>();
builder.Services.AddTransient<IUserAnswerServices, UserAnswerServices>();
builder.Services.AddTransient<IChoiceServices, ChoiceServices>();
builder.Services.AddTransient<IResultServices, ResultServices>();
//builder.Services.AddTransient<TaskSchedulerServices>();

builder.Services.AddCronJob<OpenAICronJob>(c =>
{
    c.TimeZoneInfo = TimeZoneInfo.Local;
    c.CronExpression = @"*/30 * * * *";
});


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