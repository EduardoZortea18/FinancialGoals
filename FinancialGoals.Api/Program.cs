using FinancialGoals.Api.Filters;
using FinancialGoals.Api.Helpers;
using FinancialGoals.CrossCutting;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.ConfigureInjection(builder.Configuration);

builder.Services.AddValidatorsFromAssemblyContaining<ValidationFilter>();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(
        new RouteTokenTransformerConvention(new ParameterTransformer()));
});
//.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CreateTransactionCommandValidator>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
