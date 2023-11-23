global using GeekyQuiz.Models;
global using GeekyQuiz.Services.LoginServices;
global using Microsoft.EntityFrameworkCore;
global using GeekyQuiz.Data;
global using GeekyQuiz.Services.QuestionServices;
global using GeekyQuiz.Services.ResultServices;
global using GeekyQuiz.Services.ChoiceServices;
global using GeekyQuiz.Services;
using GeekyQuiz.Cron;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => {
    options.AddPolicy(name: "AllowOrigin", policy => {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILoginServices, LoginServices>();
builder.Services.AddScoped<IQuestionServices, QuestionServices>();
builder.Services.AddScoped<IResultServices, ResultServices>();
builder.Services.AddScoped<IOptionServices, OptionServices>();
//builder.Services.AddAutoMapper(typeof(Program).Assembly);
//builder.Services.AddDbContext<DataContext>();


builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddCronJob<OpenAiCronJob>(c =>
{
    c.TimeZoneInfo = TimeZoneInfo.Local;
    c.CronExpression = @"*/30 * * * *";
});

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
    