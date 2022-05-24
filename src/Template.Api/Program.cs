using Microsoft.EntityFrameworkCore;
using Template.Api.Extension;
using Template.Api.Filters;
using Template.Api.Infrastructure.Data.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.GetSecrets();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionHandlerFilterAttribute)));

#region Context
builder.Services.AddDbContext<TemplateContext>(options =>
                options.UseSqlServer(builder.Configuration.GetSection("ConnectionString:DefaultConnection").Value));
#endregion

#region Dependency Inject
builder.Services.AddSingletons();
builder.Services.AddScopeds();
#endregion

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
